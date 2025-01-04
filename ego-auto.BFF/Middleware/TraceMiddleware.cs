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
			throw;
		}
    }
}
