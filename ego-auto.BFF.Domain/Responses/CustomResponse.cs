namespace ego_auto.BFF.Domain.Responses;

public class CustomResponse : ResponseProperties
{
    public static CustomResponse IsSuccess()
    =>
        new()
        {
            Success = true,
            Message = "Operation was successful",
            Errors = null,
            Id = default
        };

    public static CustomResponse IsSuccess(string? customProp = null)
    =>
        new()
        {
            Success = true,
            Message =
                string.Concat
                    (
                        "Operation was successful.",
                        customProp
                    ),
            Errors = null,
            Id = default
        };

    public static CustomResponse IsSuccess(int id, string? customProp = null)
    =>
        new()
        {
            Success = true,
            Message =
                string.Concat
                    (
                        "Operation was successful.",
                        customProp
                    ),
            Errors = null,
            Id = id
        };

    public static CustomResponse IsFailed()
    =>
        new()
        {
            Success = false,
            Message = "Operation wasn't successful",
            Errors = null,
            Id = default
        };

    public static CustomResponse IsFailed(List<string> errors)
    =>
        new()
        {
            Success = false,
            Message = "Operation wasn't successful",
            Errors = errors,
            Id = default
        };
}

public class CustomResponse<T> : ResponseProperties
{
    public T? Data { get; set; }

    public static CustomResponse<T> IsSuccess(T? data)
    =>
        new()
        {
            Success = true,
            Message = "Operation was successful",
            Errors = null,
            Id = default,
            Data = data
        };

    public static CustomResponse<T> IsSuccess(int id, T? data, string? customProp = null)
    =>
        new()
        {
            Success = true,
            Message =
                string.Concat
                    (
                        "Operation was successful.",
                        customProp
                    ),
            Errors = null,
            Id = id,
            Data = data
        };
}

public partial class ResponseProperties
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string>? Errors { get; set; } = null;
    public int Id { get; set; }
}