namespace Business.Models.Response;

public class ResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public static ResponseResult Exists(string? errorMessage = default) => new()
    {
        Success = true,
        StatusCode = 409,
        Message = errorMessage
    };

    public static ResponseResult InvalidModel(string? errorMessage = default) => new()
    {
        Success = false,
        StatusCode = 400,
        Message = errorMessage
    };

    public static ResponseResult Failed(string? errorMessage = default) => new()
    {
        Success = false,
        StatusCode = 500,
        Message = errorMessage
    };

    public static ResponseResult Created(string? errorMessage = default) => new()
    {
        Success = true,
        StatusCode = 201,
        Message = errorMessage
    };

    public static ResponseResult Deleted(string? successMessage = default) => new()
    {
        Success = true,
        StatusCode = 204, 
        Message = successMessage
    };

    public static ResponseResult NotFound(string? errorMessage = default) => new()
    {
        Success = false,
        StatusCode = 404,
        Message = errorMessage
    };

}


public class ResponseResult<T> : ResponseResult
{
    public T? Result { get; set; }

    public static ResponseResult<T> Ok(string? message = default, T? result = default) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message,
        Result = result
    };

    public static ResponseResult NotFound(string? message = default) => new()
    {
        Success = false,
        StatusCode = 404,
        Message = message,
    };

}