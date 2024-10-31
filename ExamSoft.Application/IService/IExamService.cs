using ExamSoft.Application.Requests.ExamRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Application.IService;

public interface IExamService
{
    Exam UpdateExam(UpdateExamRequest request);
    UpdateExamRequest GetExamRequest(int id);
    bool DeleteExam(int id);
    List<Exam> GetExams();
}