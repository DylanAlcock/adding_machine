using Adding_Machine.Models;

namespace Adding_Machine.Services
{
    public interface IAddingMachine
    {
        Task<ServiceResponse<List<History>>> GetHistory();
        Task<ServiceResponse<List<History>>> AddHistory(History equation);
        Task<ServiceResponse<List<History>>> DeleteHistory();
    }
}
