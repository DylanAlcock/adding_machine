using AddingMachine.BusinessLogic;
using AddingMachine.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddingMachine.Controllers
{
    /// <summary>
    /// Controller for the operations that are available on the adding machine
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperator _operations;

        public OperatorController(IOperator operations)
        {
            _operations = operations;
        }

        // POST api/<OperatorController>
        /// <summary>
        /// Api endpoint to solve the equation
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostSolve([FromBody] string equation)
        {
            ServiceResponse<string> result = _operations.Solve(equation);

            if (!result.Success)
                return BadRequest(result.Data);

            return Content(result.Data, "application/json");
        }


        // PUT api/<OperatorController>/sqrt
        /// <summary>
        /// Api endpoint to sqrt the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("sqrt")]
        public IActionResult PostSqrt([FromBody] string value)
        {
            ServiceResponse<string> result = _operations.Sqrt(value);
            return Content(result.Data, "application/json");
        }

        // PUT api/<OperatorController>/square
        /// <summary>
        /// Api endpoint to square the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("square")]
        public IActionResult PostSquare([FromBody] string value)
        {
            ServiceResponse<string> result = _operations.Square(value);
            return Content(result.Data, "application/json");
        }

        // PUT api/<OperatorController>/exponent
        /// <summary>
        /// Api endpoint to have a value an exponent of a second value
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost("exponent")]
        public IActionResult PostExponent([FromBody] RequestParams values)
        {
            ServiceResponse<string> result = _operations.Exponent(values);
            return Content(result.Data, "application/json");
        }

    }
}
