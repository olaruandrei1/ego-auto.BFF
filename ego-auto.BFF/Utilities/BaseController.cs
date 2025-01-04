using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ego_auto.BFF.Utilities;

public class BaseController : ControllerBase
{
    protected void LogSuccess(object request, object? response = null)
        => Log.Information(messageTemplate: "", 
                [
            
                ]);

    protected void LogError(object request, Exception ex, object? response = null)
       => Log.Error(exception: ex, messageTemplate: "",
                [
           
                ]);
}
