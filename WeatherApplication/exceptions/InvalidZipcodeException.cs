public class InvalidZipcodeException : Exception
{
    public InvalidZipcodeException()
    {
    }

    public InvalidZipcodeException(string message)
        : base(message)
    {
    }

    public InvalidZipcodeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}