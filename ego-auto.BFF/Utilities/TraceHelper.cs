using ego_auto.BFF.Application.Contracts.Application;
using ego_auto.BFF.Application.Utilities;
using ego_auto.BFF.Domain.ExceptionTypes;
using ego_auto.BFF.Domain.Responses;
using System.IdentityModel.Tokens.Jwt;

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

    //out of time - to do InstanceHelper
    public async static Task SetSessionUser(HttpContext context)
    {
        var token = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

        if (string.IsNullOrEmpty(token))
        {
            throw new IDKError("Token is missing or invalid");
        }

        var userId = AuthHelper.GetUserIdFromToken(token);

        var service = context.RequestServices.GetRequiredService<IUserService>();

        await service.SetSessionUser(userId);
    }

    public async static Task ResetSessionUser(HttpContext context)
    {
        var service = context.RequestServices.GetRequiredService<IUserService>();

        await service.ResetSessionUser();
    }
}
