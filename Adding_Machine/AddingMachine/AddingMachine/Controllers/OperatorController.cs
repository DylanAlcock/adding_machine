using AddingMachine.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
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
        public IActionResult Post([FromBody] string value)
        {
            Console.WriteLine(value);
            System.Data.DataTable table = new System.Data.DataTable();
            string resultString = string.Empty;
            try
            {
                Calculation evaluated = new Calculation(Convert.ToString(table.Compute(value, string.Empty)));
                resultString = JsonSerializer.Serialize<Calculation>(evaluated);
                JObject json = JObject.Parse(resultString);
                Console.WriteLine(json);
                return Content(resultString, "application/json");
            }
            catch
            {
                return BadRequest("Equation is not valid");
            }

        }


        // PUT api/<OperatorController>/sqrt
        [HttpPost("sqrt")]
        public IActionResult PostSqrt([FromBody] string value)
        {
            Console.WriteLine(value);
            Calculation evaluated = new Calculation(Convert.ToString(Math.Sqrt(Convert.ToDouble(value))));
            string resultString = JsonSerializer.Serialize<Calculation>(evaluated);
            Console.WriteLine(resultString);

            JObject json = JObject.Parse(resultString);
            Console.WriteLine(json);
            return Content(resultString, "application/json");
        }

        // PUT api/<OperatorController>/square
        [HttpPost("square")]
        public IActionResult PostSquare([FromBody] string value)
        {
            Console.WriteLine(value);
            Calculation evaluated = new Calculation(Convert.ToString(Math.Pow(Convert.ToDouble(value), 2)));
            string resultString = JsonSerializer.Serialize<Calculation>(evaluated);
            Console.WriteLine(resultString);

            JObject json = JObject.Parse(resultString);
            Console.WriteLine(json);
            return Content(resultString, "application/json");
        }

        // PUT api/<OperatorController>/exponent
        [HttpPost("exponent")]
        public IActionResult PostExponent([FromBody] RequestParams values)
        {
            Console.WriteLine(values.value1);
            Calculation evaluated = new Calculation(Convert.ToString(Math.Pow(Convert.ToDouble(values.value1), Convert.ToDouble(values.value2))));
            string resultString = JsonSerializer.Serialize<Calculation>(evaluated);
            Console.WriteLine(resultString);

            JObject json = JObject.Parse(resultString);
            Console.WriteLine(json);
            return Content(resultString, "application/json");
        }

    }
}
