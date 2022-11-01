using AddingMachine.Models;

namespace AddingMachine.BusinessLogic
{
    /// <summary>
    /// Interface for operator to complete operations from the adding machine
    /// </summary>
    public interface IOperator
    {
        /// <summary>
        /// Takes a math equation and returns the solved calculation
        /// </summary>
        /// <param name="equation">Math expression to be solved</param>
        /// <returns></returns>
        ServiceResponse<string> Solve(string equation);

        /// <summary>
        /// Takes a value and returns the sqrt of that value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ServiceResponse<string> Sqrt(string value);

        /// <summary>
        /// Takes a value and returns the square of the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ServiceResponse<string> Square(string value);

        /// <summary>
        /// Takes two values and returns value1^^value2
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        ServiceResponse<string> Exponent(RequestParams values);

    }
}
