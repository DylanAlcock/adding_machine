namespace AddingMachine.Models
{
    /// <summary>
    /// Class for returning data from business logic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public ServiceResponse() { }

        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
