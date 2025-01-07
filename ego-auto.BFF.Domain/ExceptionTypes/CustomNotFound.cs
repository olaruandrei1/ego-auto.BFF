namespace ego_auto.BFF.Domain.ExceptionTypes;

public class CustomNotFound : ApplicationException
{
    public CustomNotFound(string message) : base(message) { }

    public CustomNotFound(string message, Exception innerException) : base(message, innerException) { }
}
