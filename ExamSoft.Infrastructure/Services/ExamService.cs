using ExamSoft.Application.IRepository.Base;
using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.ExamRequest;
using ExamSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamSoft.Infrastructure.Services;

public class ExamService : IExamService
{
    private readonly IBaseRepository<Exam> _ExamRepository;

    public ExamService(IBaseRepository<Exam> examRepository)
    {
        _ExamRepository = examRepository;
    }

    public Exam UpdateExam(UpdateExamRequest request)
    {
       
        Exam Entity;
        
        try
        {
            Entity = request.ConvertToEntity();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return _ExamRepository.Save(Entity);
    }

    public UpdateExamRequest GetExamRequest(int id)
    {
        Exam Exam = _ExamRepository.GetAll().FirstOrDefault(x => x.Id == id);
        return Exam is null ? null : new UpdateExamRequest().ConvertToRequest(Exam);
    }

    public bool DeleteExam(int id)
    {
        Exam Exam = _ExamRepository.GetAll()
            .FirstOrDefault(x => x.Id == id);
        
        if (Exam != null )
        {
            Exam.Delete();
            _ExamRepository.Save(Exam);
            // exams silinmelidirmi ?  -- .Include(x=>x.Exams)
            return Exam.Deleted;
        }
        return false;
    }

    public List<Exam> GetExams()
    {
        return _ExamRepository.GetAll()
            .Include(x=>x.Lesson)
            .Include(x=>x.Student)
            .ToList();
    }
}

