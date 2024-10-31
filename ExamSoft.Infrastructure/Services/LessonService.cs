using ExamSoft.Application.IRepository.Base;
using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.LessonRequest;
using ExamSoft.Domain.Entities;

namespace ExamSoft.Infrastructure.Services;

public class LessonService : ILessonService
{
    private readonly IBaseRepository<Lesson> _lessonRepository;

    public LessonService(IBaseRepository<Lesson> lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }
    
    public Lesson UpdateLesson(UpdateLessonRequest request)
    {
        Lesson Entity;
        try
        {
            Entity = request.ConvertToEntity();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return _lessonRepository.Save(Entity);
    }

    public UpdateLessonRequest GetLessonRequest(int id)
    {
        Lesson lesson = _lessonRepository.GetAll().FirstOrDefault(x => x.Id == id);
        return lesson is null ? null : new UpdateLessonRequest().ConvertToRequest(lesson);
    }

    public bool DeleteLesson(int id)
    {
        Lesson lesson = _lessonRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if (lesson != null )
        {
            lesson.Delete();
            _lessonRepository.Save(lesson);
            return lesson.Deleted;
        }
        return false;
    }

    public List<Lesson> GetLessons()
    {
        return _lessonRepository.GetAll().ToList();
    }
}