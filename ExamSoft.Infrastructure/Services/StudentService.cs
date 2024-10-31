using ExamSoft.Application.IRepository.Base;
using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.StudentRequest;
using ExamSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamSoft.Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly IBaseRepository<Student> _studentRepository;
    private readonly IBaseRepository<Exam> _examRepository;
    private readonly IBaseRepository<Lesson> _lessonRepository;

    public StudentService(IBaseRepository<Student> studentRepository, IBaseRepository<Exam> examRepository, IBaseRepository<Lesson> lessonRepository)
    {
        _studentRepository = studentRepository;
        _examRepository = examRepository;
        _lessonRepository = lessonRepository;
    }
    public Student UpdateStudent(UpdateStudentRequest request)
    {
        Student Entity;
        try
        {
            Entity = request.ConvertToEntity();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return _studentRepository.Save(Entity);
    }

    public UpdateStudentRequest GetStudentRequest(int id)
    {
        Student student = _studentRepository.GetAll().FirstOrDefault(x => x.Id == id);
        return student is null ? null : new UpdateStudentRequest().ConvertToRequest(student);
    }

    public bool DeleteStudent(int id)
    {
        Student student = _studentRepository.GetAll()
            .FirstOrDefault(x => x.Id == id);
        
        if (student != null )
        {
            student.Delete();
            _studentRepository.Save(student);
            // exams silinmelidirmi ?  -- .Include(x=>x.Exams)
            return student.Deleted;
        }
        return false;
    }

    public List<Student> GetStudents()
    {
        return _studentRepository.GetAll().ToList();
    }
}