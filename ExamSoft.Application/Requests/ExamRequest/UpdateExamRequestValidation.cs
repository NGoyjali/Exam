using FluentValidation;

namespace ExamSoft.Application.Requests.ExamRequest;

public class UpdateExamRequestValidation : AbstractValidator<UpdateExamRequest> , BaseValidate
{

    public UpdateExamRequestValidation()
    {
        RuleFor(x=>x.LessonCode)
            .NotNull().WithMessage("Ders kodu bos olabilmez")
            .MaximumLength(3).WithMessage("Ders kodu  uzunlugu 3 den cox olabilmez")
            .MinimumLength(3).WithMessage("Ders kodu  uzunlugu 3 den az olabilmez");
        
        RuleFor(x => x.StudentNumber)
            .NotNull().WithMessage("Sagirdin nomresi bos olabilmez")
            .LessThan(99999).WithMessage("Sagirdin nomresi 99999 den boyuk olabilmez")
            .GreaterThan(0).WithMessage("Sagirdin nomresi 1 den kicik olabilmez");
        
        RuleFor(x => x.Score)
            .NotNull().WithMessage("Sagirdin nomresi bos olabilmez")
            .LessThan(99).WithMessage("Sagirdin Qiyməti 99 dan boyuk olabilmez")
            .GreaterThan(-1).WithMessage("Sagirdin Qiyməti 0 den kicik olabilmez");
        
        RuleFor(x => x.Date)
            .NotNull().WithMessage("İmtahan tarixi bos olabilmez");
        
        RuleFor(x => x.Lesson)
            .NotNull().WithMessage("Əvvəlcə dərs əlavə edin Dərs ");
        
        RuleFor(x => x.Student)
            .NotNull().WithMessage("Əvvəlcə Şagird əlavə edin");
        

    }
    
}