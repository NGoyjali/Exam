using ExamSoft.Application.Requests.LessonRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Presentation.ViewModels;

public class LessonListViewModel
{
    public List<Lesson> List { get; set; }
    public UpdateLessonRequest UpdateLessonRequest { get; set; } = new ();
}