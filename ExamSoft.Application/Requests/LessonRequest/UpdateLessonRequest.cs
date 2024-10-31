using ExamSoft.Domain.Entities;
using ExamSoft.Domain.Entities.ValueObjects.LessonEntity;
using ExamSoft.Domain.Exceptions;
using FluentValidation.Results;

namespace ExamSoft.Application.Requests.LessonRequest;

public class UpdateLessonRequest : BaseRequest<UpdateLessonRequestValidation>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Class { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }
    
    public override ValidationResult Validate(UpdateLessonRequestValidation obj)
    {
        var result =  obj.Validate(this);
        validatinResult = result.IsValid;
        return result;
    }
    
    public Lesson ConvertToEntity()
    {
        if (!validatinResult)
            throw new ModelIsNotValidException("Melumatlari duzgun doldurun");

        LessonCode lessonCode = new LessonCode(Code);
        Teacher teacher = new Teacher(TeacherName, TeacherSurname);
        return new Lesson(lessonCode, Name, Class, teacher,Id);
    }

    public UpdateLessonRequest ConvertToRequest( Lesson data)
    {
        Name = data.Name;
        Code = data.Code.Value;
        Id = data.Id;
        Class = data.Class;
        TeacherName = data.Teacher.Name;
        TeacherSurname = data.Teacher.Surname;
        return this;
    }

    
}