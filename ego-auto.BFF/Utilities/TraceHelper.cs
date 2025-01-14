using ego_auto.BFF.Application.Contracts.Application;
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

    public async static Task SetSessionUser(HttpContext context, bool setUser)
    {
        var userContextService = context.RequestServices.GetRequiredService<IUserService>();

        if (setUser)
            await userContextService.SetSessionUser(null);
        else
        {
            var userId = context.User.FindFirst("id")?.Value;

            if (!string.IsNullOrEmpty(userId))
                await userContextService.SetSessionUser(userId);
        }
    }
}
