using ExamSoft.Domain.Entities;
using FluentValidation;

namespace ExamSoft.Application.Requests.StudentRequest;

public class UpdateStudentRequestValidation : AbstractValidator<UpdateStudentRequest> , BaseValidate
{
    public UpdateStudentRequestValidation()
    {
        RuleFor(x=>x.Name)
            .NotNull().WithMessage("Şagirdin adı bos olabilmez")
            .MaximumLength(30).WithMessage("Şagirdin adınin uzunlugu 30 dan cox olabilmez");
        
        RuleFor(x=>x.SurName)
            .NotNull().WithMessage("Şagirdin soyadı bos olabilmez")
            .MaximumLength(30).WithMessage("Şagirdin soyadının uzunlugu 30 dan cox olabilmez");
        
        RuleFor(x => x.Number)
            .NotNull().WithMessage("Sagirdin nomresi bos olabilmez")
            .LessThan(99999).WithMessage("Sagirdin nomresi 99999 den boyuk olabilmez")
            .GreaterThan(0).WithMessage("Sagirdin nomresi 1 den kicik olabilmez");
        
        RuleFor(x => x.Class)
            .NotNull().WithMessage("Sinif bos olabilmez")
            .LessThan(13).WithMessage("sinif 12 den boyuk olabilmez")
            .GreaterThan(0).WithMessage("sinif 1 den kicik olabilmez");
        
    }
}