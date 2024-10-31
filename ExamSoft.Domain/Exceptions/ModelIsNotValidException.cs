namespace ExamSoft.Domain.Exceptions;

public class ModelIsNotValidException: BaseException
{
    public ModelIsNotValidException(string message) : base(message)
    {
    }
}