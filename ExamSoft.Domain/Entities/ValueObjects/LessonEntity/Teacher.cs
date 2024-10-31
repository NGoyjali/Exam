using System.ComponentModel.DataAnnotations;
using ExamSoft.Domain.Exceptions;

namespace ExamSoft.Domain.Entities.ValueObjects.LessonEntity;

public class Teacher
{
    // Dərsi verən müəllimin adı - VARCHAR(20)
    [MaxLength(20)]
    public string Name { get; init; }

    // Dərsi verən müəllimin soyadı - VARCHAR(20)
    [MaxLength(20)]
    public string Surname { get; init; }

    public Teacher(string name, string surname)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            throw new InvalidTeacherPropertyException("Mellimin melumatlarini duzgun doldurun.");
            
        Name = name;
        Surname = surname;
    }

   
}