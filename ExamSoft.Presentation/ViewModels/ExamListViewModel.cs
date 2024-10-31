using ExamSoft.Application.Requests.ExamRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Presentation.ViewModels;

public class ExamListViewModel
{
    public List<Exam> List { get; set; }
    public UpdateExamRequest Request { get; set; } = new ();
}