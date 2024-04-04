using System.Net;

namespace OMSATrackingAPI.BLL.Utils
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; } = [];
        public object? Payload { get; set; }

        public Response FailedResponse(HttpStatusCode statusCode, string errors)
        {
            StatusCode = statusCode;
            Payload = null;
            IsSuccess = false;
            ErrorMessages.Add(errors);
            return this;
        }

        public Response SuccessResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Payload = message;
            IsSuccess = true;
            return this;
        }
    }
}
