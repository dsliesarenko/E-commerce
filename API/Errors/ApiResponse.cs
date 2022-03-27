using System.Net;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(HttpStatusCode statusCode)
        {
            return statusCode.ToString();
        }
    }
}
