using System.ComponentModel.DataAnnotations;
using ExamSoft.Domain.Complex;

namespace ExamSoft.Domain.Entities;

public class Student : BaseEntity
{
    // Adı - VARCHAR(30)
    [MaxLength(30)]
    [Required]
    public string Name { get; set; }
    
    // Soyadı - VARCHAR(30)
    [MaxLength(30)]
    [Required]
    public string SurName { get; set; }

    // Sinifi - NUMBER(2,0)
    [Range(0, 99)]
    public int Class { get; set; }
    
    // Nomresi - NUMBER(5,0)
    [Range(0, 99999)]
    public int Number { get; set; }

    // Relations
    public List<Lesson> Lessons { get; set; } = new();
    public List<Exam> Exams { get; set; } = new();


    public Student(string name, string surName, int @class, int number, int id=0)
    {
        Name = name;
        SurName = surName;
        Class = @class;
        Number = number;
        Id = id;
    }
}