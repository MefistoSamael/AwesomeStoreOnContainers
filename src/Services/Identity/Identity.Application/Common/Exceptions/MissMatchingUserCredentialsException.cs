namespace Identity.Application.Common.Exceptions;

public class MissMatchingUserCredentialsException : Exception
{
    public MissMatchingUserCredentialsException() 
    { }

    public MissMatchingUserCredentialsException(string? message) : base(message)
    { }

    public MissMatchingUserCredentialsException(string? message, Exception? innerException) : base(message, innerException)
    { }
}
