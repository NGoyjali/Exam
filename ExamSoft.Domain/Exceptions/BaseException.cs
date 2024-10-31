namespace ExamSoft.Domain.Exceptions;

public class BaseException : Exception
{
    public string Message { get; set; }

    public BaseException(string message):base(message)
    {
        Message = message;
    }
}