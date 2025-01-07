using ego_auto.BFF.Domain.ExceptionTypes;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Utilities;

public class TraceHelper
{
    public static (int statusCode, CustomResponse responseObj) HandleExceptions(Exception ex)
    {
        var httpStatusCode = ex switch
        {
            CustomNotFound => StatusCodes.Status404NotFound,
            CustomBadRequest => StatusCodes.Status400BadRequest,
            IDKError => StatusCodes.Status418ImATeapot,
            _ => StatusCodes.Status500InternalServerError
        };

        return (httpStatusCode, CustomResponse.IsFailed(message: ex.InnerException.Message, errors: [ex.Message]));
    }
}
