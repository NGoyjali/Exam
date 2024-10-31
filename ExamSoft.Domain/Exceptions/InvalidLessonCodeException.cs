using ExamSoft.Domain.Complex;

namespace ExamSoft.Domain.Exceptions;

public class InvalidLessonCodeException : BaseException
{
    public InvalidLessonCodeException(string message) : base(message)
    {
        
    }
}