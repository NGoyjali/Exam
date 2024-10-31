using System.ComponentModel.DataAnnotations;
using ExamSoft.Domain.Complex;
using ExamSoft.Domain.Exceptions;

namespace ExamSoft.Domain.Entities.ValueObjects.LessonEntity;

public class LessonCode 
{
    // Dərsin kodu - CHAR(3)
    [MaxLength(3)]
    [Required] 
    public string Value { get; init; }

    public LessonCode(string value)
    {
        if (value.Length > 3)
            throw new InvalidLessonCodeException("Dərsin kodunun uzunluğu 3 dən böyük olabilməz. ");
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidLessonCodeException("Dərsin kodu boş olabilməz. ");
        Value = value;
    }
}