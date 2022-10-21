using Adding_Machine.Models;
using Adding_Machine.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Adding_Machine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddingMachineController : ControllerBase
    {
        private readonly IAddingMachine _addingMachine;

        public AddingMachineController(IAddingMachine addingMachine)
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
        public async Task<ActionResult<History>> AddEquation(string value)
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
