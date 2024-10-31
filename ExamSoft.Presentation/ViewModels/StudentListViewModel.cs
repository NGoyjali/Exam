using ExamSoft.Application.Requests.StudentRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Presentation.ViewModels;

public class StudentListViewModel
{
    public List<Student> List { get; set; }
    public UpdateStudentRequest Request { get; set; }
}