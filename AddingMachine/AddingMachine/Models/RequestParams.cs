namespace AddingMachine.Models
{
    //Class for getting two values from the body when request is sent to api endpoint
    [Serializable]
    public class RequestParams
    {
        public string value1 { get; set; } = string.Empty;
        public string value2 { get; set; } = string.Empty;
    }
}
