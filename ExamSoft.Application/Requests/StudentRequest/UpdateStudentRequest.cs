using ExamSoft.Application.Requests.LessonRequest;
using ExamSoft.Domain.Entities;
using ExamSoft.Domain.Entities.ValueObjects.LessonEntity;
using ExamSoft.Domain.Exceptions;
using FluentValidation.Results;

namespace ExamSoft.Application.Requests.StudentRequest;

public class UpdateStudentRequest  : BaseRequest<UpdateStudentRequestValidation>
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public int Class { get; set; }
    
    public override ValidationResult Validate(UpdateStudentRequestValidation obj)
    {
        var result =  obj.Validate(this);
        validatinResult = result.IsValid;
        return result;
    }
    
    public Student ConvertToEntity()
    {
        if (!validatinResult)
            throw new ModelIsNotValidException("Melumatlari duzgun doldurun");
        
        
        return new Student(Name,SurName,Class,Number,Id);
    }

    public UpdateStudentRequest ConvertToRequest( Student data)
    {
        return this;
    }
}