using ExamSoft.Application.Requests.StudentRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Application.IService;

public interface IStudentService
{
    Student UpdateStudent(UpdateStudentRequest request);
    UpdateStudentRequest GetStudentRequest(int id);
    bool DeleteStudent(int id);
    List<Student> GetStudents();
}