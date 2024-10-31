using ExamSoft.Application.Requests.LessonRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Application.IService;

public interface ILessonService
{
    Lesson UpdateLesson(UpdateLessonRequest request);
    UpdateLessonRequest GetLessonRequest(int id);
    bool DeleteLesson(int id);
    List<Lesson> GetLessons();


}