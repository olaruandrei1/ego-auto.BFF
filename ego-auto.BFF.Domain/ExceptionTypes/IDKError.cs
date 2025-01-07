namespace ego_auto.BFF.Domain.ExceptionTypes;

public class IDKError : ApplicationException
{
    public IDKError(string message) : base(message) { }

    public IDKError(string message, Exception innerException) : base(message, innerException) { }
}
