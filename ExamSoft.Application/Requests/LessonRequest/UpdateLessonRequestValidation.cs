using FluentValidation;

namespace ExamSoft.Application.Requests.LessonRequest;

public class UpdateLessonRequestValidation : AbstractValidator<UpdateLessonRequest> , BaseValidate
{
    public UpdateLessonRequestValidation()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id bos olabilmez");

        RuleFor(x=>x.Name)
            .NotNull().WithMessage("Ad bos olabilmez")
            .MaximumLength(30).WithMessage("Adin uzunlugu 30 dan cox olabilmez");
        
        RuleFor(x => x.Class)
            .NotNull().WithMessage("Sinif bos olabilmez")
            .LessThan(13).WithMessage("sinif 12 den boyuk olabilmez")
            .GreaterThan(0).WithMessage("sinif 1 den kicik olabilmez");
        
        RuleFor(x=>x.Code)
            .NotNull().WithMessage("Ders kodu bos olabilmez")
            .MaximumLength(3).WithMessage("Ders kodu  uzunlugu 3 den cox olabilmez")
            .MinimumLength(3).WithMessage("Ders kodu  uzunlugu 3 den az olabilmez");
        
        RuleFor(x=>x.TeacherName)
            .NotNull().WithMessage("Dərsi verən müəllimin adı bos olabilmez")
            .MaximumLength(20).WithMessage("Dərsi verən müəllimin adınin uzunlugu 20 dan cox olabilmez");
        
        RuleFor(x=>x.TeacherSurname)
            .NotNull().WithMessage("Dərsi verən müəllimin soyadı bos olabilmez")
            .MaximumLength(20).WithMessage("Dərsi verən müəllimin soyadının uzunlugu 20 dan cox olabilmez");
        
        
    }
}