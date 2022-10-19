using Adding_Machine.Models;
using Microsoft.EntityFrameworkCore;


namespace Adding_Machine.Services
{
    public class AddingMachine : IAddingMachine
    {
        private readonly AddingMachineDbContext _context;

        public AddingMachine(AddingMachineDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<History>>> AddHistory(History equation)
        {
            _context.History.Add(equation);
            await _context.SaveChangesAsync();

            return await GetHistory();
        }

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
