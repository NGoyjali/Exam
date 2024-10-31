using ExamSoft.Domain.Entities;
using ExamSoft.Domain.Exceptions;
using FluentValidation.Results;

namespace ExamSoft.Application.Requests.ExamRequest;

public class UpdateExamRequest  : BaseRequest<UpdateExamRequestValidation>
{
    public int Id { get; set; }
    public string LessonCode { get; set; }
    public int StudentNumber { get; set; }
    public DateTimeOffset Date { get; set; }
    public int Score { get; set; }
    public Lesson Lesson { get; set; }
    public Student Student { get; set; }
    
    
    public override ValidationResult Validate(UpdateExamRequestValidation obj)
    {
        var result =  obj.Validate(this);
        validatinResult = result.IsValid;
        return result;
    }
    
    public Exam ConvertToEntity()
    {
        if (!validatinResult)
            throw new ModelIsNotValidException("Melumatlari duzgun doldurun");
        return new Exam(Date,Score,Lesson.Id,Student.Id,Id);
    }

    public UpdateExamRequest ConvertToRequest( Exam data)
    {
        Id = data.Id;
        LessonCode = data.Lesson.Code.Value;
        Date = data.Date;
        StudentNumber = data.Student.Number;
        Score = data.Score;
        
        Lesson = data.Lesson;
        Student = data.Student;
        return this;
    }
}