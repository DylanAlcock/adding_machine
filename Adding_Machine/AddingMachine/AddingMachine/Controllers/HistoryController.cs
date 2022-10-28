using Adding_Machine;
using AddingMachine.Models;
using AddingMachine.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddingMachine.Controllers
{
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


        // GET: api/AddingMachine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistory()
        {
            ServiceResponse<List<History>> result = await _addingMachine.GetHistory();
            return Ok(result);
        }


        // POST api/<AddingMachineController>
        [HttpPost]
        public async Task<ActionResult<History>> AddHistory([FromBody] string value)
        {
            ServiceResponse<List<History>> result = await _addingMachine.AddHistory(value);
            return Ok(result);
        }


        // DELETE api/<AddingMachineController>
        [HttpDelete]
        public async Task<ActionResult<History>> DeleteHistory()
        {
            ServiceResponse<List<History>> result = await _addingMachine.DeleteHistory();
            return Ok(result);
        }
    }
}
