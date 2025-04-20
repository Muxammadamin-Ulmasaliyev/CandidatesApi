using System.Net;

namespace Candidates.Core.DTOs.General;

public class ResponseModel<T>
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string? Error { get; set; }
    public T? Result { get; set; }

    public ResponseModel() { }

    public ResponseModel(T result)
    {
        StatusCode = HttpStatusCode.OK;
        Result = result;
    }
    public ResponseModel(T result, HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Result = result;
    }

    public ResponseModel(string error, HttpStatusCode statusCode = HttpStatusCode.BadRequest, T? result = default)
    {
        Error = error;
        StatusCode = statusCode;
        Result = result;
    }
}
