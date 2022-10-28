namespace AddingMachine.Models
{
    [Serializable]
    public class Calculation
    {
        public string calc { get; set; } = string.Empty;

        public Calculation(string _calc)
        {
            this.calc = _calc;
        }
    }
}
