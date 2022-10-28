using Adding_Machine;
using AddingMachine.Models;

namespace AddingMachine.Services
{
    public interface IAddMachine
    {
        Task<ServiceResponse<List<History>>> GetHistory();
        Task<ServiceResponse<List<History>>> AddHistory(string equation);
        Task<ServiceResponse<List<History>>> DeleteHistory();
    }
}
