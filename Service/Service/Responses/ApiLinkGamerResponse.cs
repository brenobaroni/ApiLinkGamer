namespace Service.Service
{
    public class ApiLinkGamerResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }

        public ApiLinkGamerResponse(bool success)
        {
            Success = success;
        }

        public ApiLinkGamerResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ApiLinkGamerResponse(bool success, object result)
        {
            Success = success;
            Result = result;
        }

        public ApiLinkGamerResponse(bool success, string message, object result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}