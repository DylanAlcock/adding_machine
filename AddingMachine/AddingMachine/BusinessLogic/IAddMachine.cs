using AddingMachine.Models;

namespace AddingMachine.BusinessLogic
{
    /// <summary>
    /// Interface for implementing the AddMachine functions for connections to database
    /// </summary>
    public interface IAddMachine
    {
        /// <summary>
        /// Gets the history items from the database
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<History>>> GetHistory();

        /// <summary>
        /// Add and item to the history database
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<History>>> AddHistory(string equation);

        /// <summary>
        /// Soft delete entries from the database
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<History>>> DeleteHistory();
    }
}
