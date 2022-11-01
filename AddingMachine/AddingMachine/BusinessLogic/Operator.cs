using AddingMachine.Models;
using System.Text.Json;

namespace AddingMachine.BusinessLogic
{
    /// <summary>
    /// Class for the operations available on the adding machine
    /// </summary>
    public class Operator : IOperator
    {
        /// <summary>
        /// Solves the equation from the equation parameter and returns the calculated solution
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public ServiceResponse<string> Solve(string equation)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                //this takes the string equation and computes the value
                Calculation evaluated = new Calculation(Convert.ToString(table.Compute(equation, string.Empty)));
                response.Data = JsonSerializer.Serialize<Calculation>(evaluated);
                return response;
            }
            catch
            {
                response.Data = "Equation is not valid";
                response.Success = false;
                return response;
            }
        }

        /// <summary>
        /// Square roots the value given in the parameter
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceResponse<string> Sqrt(string value)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Calculation evaluated = new Calculation(Convert.ToString(Math.Sqrt(Convert.ToDouble(value))));
            response.Data = JsonSerializer.Serialize<Calculation>(evaluated);
            return response;
        }

        /// <summary>
        /// Squares the value given in the parameter
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ServiceResponse<string> Square(string value)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Calculation evaluated = new Calculation(Convert.ToString(Math.Pow(Convert.ToDouble(value), 2)));
            response.Data = JsonSerializer.Serialize<Calculation>(evaluated);
            return response;
        }

        /// <summary>
        /// Returns the value of the first value with the second value as the exponent
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public ServiceResponse<string> Exponent(RequestParams values)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Calculation evaluated = new Calculation(Convert.ToString(Math.Pow(Convert.ToDouble(values.value1), Convert.ToDouble(values.value2))));
            response.Data = JsonSerializer.Serialize<Calculation>(evaluated);
            return response;
        }
    }
}
