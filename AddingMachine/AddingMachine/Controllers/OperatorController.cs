using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Adding_Machine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        // GET: api/<OperatorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<OperatorController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToString(table.Compute(value, string.Empty));
        }


        // PUT api/<OperatorController>/sqrt
        [HttpPost("sqrt")]
        public string PostSqrt([FromBody] string value)
        {
            string evaluatedValue = Convert.ToString(Math.Sqrt(Convert.ToDouble(value)));
            return evaluatedValue;

        }

        // PUT api/<OperatorController>/sqrt
        [HttpPost("square")]
        public void PostSquare([FromBody] string value)
        {
        }

        // PUT api/<OperatorController>/sqrt
        [HttpPost("exponent")]
        public void PostExponent([FromBody] string value)
        {
        }

    }
}
