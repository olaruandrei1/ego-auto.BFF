using ego_auto.BFF.Utilities;
using System.Text.Json;

namespace ego_auto.BFF.Middleware;

public class TraceMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var (statusCode, responseObj) = TraceHelper.HandleExceptions(ex);

            context.Response.StatusCode = statusCode;

            context.Response.ContentType = "application/json";

            var responseJson = JsonSerializer.Serialize(responseObj);

            await context.Response.WriteAsync(responseJson);
        }
    }
}
