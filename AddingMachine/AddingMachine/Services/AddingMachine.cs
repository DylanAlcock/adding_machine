using Adding_Machine.Models;
using Microsoft.EntityFrameworkCore;


namespace Adding_Machine.Services
{

    /// <summary>
    /// Handles the entity framework requests to the database
    /// </summary>
    public class AddingMachine : IAddingMachine
    {
        private readonly AddingMachineDbContext _context;

        public AddingMachine(AddingMachineDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// When an equation is entered on the adding machine saves it to the database
        /// </summary>
        /// <param name="equation"></param>
        /// <returns>A list of all the History items</returns>
        public async Task<ServiceResponse<List<History>>> AddHistory(string equation)
        {
            History hist = new History();
            hist.Equation = equation;
            _context.History.Add(hist);
            await _context.SaveChangesAsync();

            return await GetHistory();
        }


        /// <summary>
        /// Soft delete for all the history items, keeps them in the db just sets deleted to true
        /// </summary>
        /// <returns>List of history items, which should be empty now</returns>
        public async Task<ServiceResponse<List<History>>> DeleteHistory()
        {
            ServiceResponse<List<History>> history = await GetHistory();
            if (history == null)
            {
                return new ServiceResponse<List<History>>();
            }
            await _context.History.ForEachAsync(h => h.Deleted = true);

            await _context.SaveChangesAsync();
            return await GetHistory();
        }

        /// <summary>
        /// Get all history items from the db that haven't been deleted
        /// </summary>
        /// <returns>List of history items</returns>
        public async Task<ServiceResponse<List<History>>> GetHistory()
        {
            List<History> equations = await _context.History
               .Where(eq => eq.Deleted == false)
               .ToListAsync();
            return new ServiceResponse<List<History>>
            {
                Data = equations
            };
        }
    }
}
