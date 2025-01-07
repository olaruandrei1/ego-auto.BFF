namespace ego_auto.BFF.Domain.ExceptionTypes;

public class CustomBadRequest : ApplicationException
{
    public CustomBadRequest(string message) : base(message) { }

    public CustomBadRequest(string message, Exception innerException) : base(message, innerException) { }
}
