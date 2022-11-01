using AddingMachine.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace AddingMachine.BusinessLogic
{
    /// <summary>
    /// Handles the entity framework requests to the database
    /// </summary>
    public class AddMachine : IAddMachine
    {
        private readonly HistoryDbContext _context;

        public AddMachine(HistoryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// When an equation is entered on the adding machine saves it to the database
        /// </summary>
        /// <param name="equation">Adding calculator equation with solution ie. 2+3=5</param>
        /// <returns>A list of all the History items</returns>
        public async Task<ServiceResponse<List<History>>> AddHistory(string equation)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }, TransactionScopeAsyncFlowOption.Enabled))
            {
                History hist = new History
                {
                    Equation = equation
                };
                await _context.History.AddAsync(hist);
                await _context.SaveChangesAsync();
                scope.Complete();
            }
            return await GetHistory();
        }

        /// <summary>
        /// Soft delete for all the history items, keeps them in the db just sets deleted to true
        /// </summary>
        /// <returns>List of history items, which should be empty now</returns>
        public async Task<ServiceResponse<List<History>>> DeleteHistory()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            }, TransactionScopeAsyncFlowOption.Enabled))
            {
                ServiceResponse<List<History>> history = await GetHistory();
                if (history == null)
                {
                    return new ServiceResponse<List<History>>();
                }
            }

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted
            }, TransactionScopeAsyncFlowOption.Enabled))
            {
                await _context.History
                    .Where(h => h.Deleted == false)
                    .ForEachAsync(h => h.Deleted = true);

                await _context.SaveChangesAsync();
                scope.Complete();
            }

            return await GetHistory();
        }

        /// <summary>
        /// Get all history items from the db that haven't been deleted
        /// </summary>
        /// <returns>List of history items</returns>
        public async Task<ServiceResponse<List<History>>> GetHistory()
        {
            List<History> equations = new List<History>();

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }, TransactionScopeAsyncFlowOption.Enabled))
            {
                equations = await _context.History
               .Where(eq => eq.Deleted == false)
               .ToListAsync();
                scope.Complete();
            }
            return new ServiceResponse<List<History>>
            {
                Data = equations
            };
        }
    }
}
