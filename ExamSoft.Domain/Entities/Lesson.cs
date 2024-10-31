using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ExamSoft.Domain.Complex;
using ExamSoft.Domain.Entities.ValueObjects.LessonEntity;
using ExamSoft.Domain.Exceptions;

namespace ExamSoft.Domain.Entities;

public class Lesson : BaseEntity 
{
    public LessonCode Code { get; init; }

    // Dərsin adı - VARCHAR(30)
    [MaxLength(30)]
    [Required]
    public string Name { get; set; }

    // Sinifi - NUMBER(2,0)
    [Range(0, 99)]
    [Required]
    public int Class { get; set; }

    public Teacher Teacher { get; init; }  
    
    
    // Relations
    [JsonIgnore]
    public List<Exam> Exams { get; set; } = new();
    [JsonIgnore]
    public List<Student> Students { get; set; } = new();

    public Lesson(LessonCode code, string name, int @class, Teacher teacher, int id = 0)
    {
        if (@class < 1)
            throw new InvalidPropertyException("Sinif melumatini duzgun girin.");
        Code = code;
        Name = name;
        Class = @class;
        Teacher = teacher;
        Id = id;
    }

    public Lesson()
    {
    }
   
}