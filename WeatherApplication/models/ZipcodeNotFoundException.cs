public class ZipcodeNotFoundException : Exception
{
    public ZipcodeNotFoundException()
    {
    }

    public ZipcodeNotFoundException(string message)
        : base(message)
    {
    }

    public ZipcodeNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}