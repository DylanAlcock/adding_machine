using AddingMachine.BusinessLogic;
using AddingMachine.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace AddingMachine.Controllers
{
    /// <summary>
    /// Controller for managing operations to the database using entity framework
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class HistoryController : ControllerBase
    {
        private readonly IAddMachine _addingMachine;

        public HistoryController(IAddMachine addingMachine)
        {
            _addingMachine = addingMachine;
        }

        // GET: api/<HistoryController>
        /// <summary>
        /// Api endpoint to get the adding calculators equations history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistory()
        {
            ServiceResponse<List<History>> result = await _addingMachine.GetHistory();
            return Ok(result);
        }

        // POST api/<HistoryController>
        /// <summary>
        /// Api endpoint to add equation to the history
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<History>> AddHistory([FromBody] string equation)
        {
            ServiceResponse<List<History>> result = await _addingMachine.AddHistory(equation);
            return Ok(result);
        }

        // DELETE api/<HistoryController>
        /// <summary>
        /// Api endpoint to delete the adding machines history
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<History>> DeleteHistory()
        {
            ServiceResponse<List<History>> result = await _addingMachine.DeleteHistory();
            return Ok(result);
        }
    }
}
