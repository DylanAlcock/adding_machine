namespace AddingMachine.Models
{
    /// <summary>
    /// Class used for sending the equation to through the api in json format
    /// </summary>
    [Serializable]
    public class Calculation
    {
        /// <summary>
        /// Stores the string to be sent to the api for solving
        /// </summary>
        public string calc { get; set; } = string.Empty;

        public Calculation(string _calc)
        {
            this.calc = _calc;
        }
    }
}
