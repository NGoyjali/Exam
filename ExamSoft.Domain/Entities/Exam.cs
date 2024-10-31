using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ExamSoft.Domain.Complex;

namespace ExamSoft.Domain.Entities;

public class Exam : BaseEntity
{
    // İmtahan tarixi - date
    [Required]
    public DateTimeOffset Date { get; set; }
    
    // Qiyməti – number (1,0)
    [Range(0,10)]
    [Required]
    public int Score { get; set; }
    
    // Relations
    [JsonIgnore] 
    public Lesson Lesson { get; set; } 
    public int LessonId { get; set; }
    
    public Student Student { get; set; } 
    public int StudentId { get; set; }

    public Exam(DateTimeOffset date, int score, int lessonId, int studentId, int id = 0)
    {
        Date = date;
        Score = score;
        LessonId = lessonId;
        StudentId = studentId;
        Id = id;
    }
}