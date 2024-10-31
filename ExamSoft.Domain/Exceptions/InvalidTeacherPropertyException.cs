namespace ExamSoft.Domain.Exceptions;

public class InvalidTeacherPropertyException : BaseException
{
    public InvalidTeacherPropertyException(string message) : base(message)
    {
    }
}