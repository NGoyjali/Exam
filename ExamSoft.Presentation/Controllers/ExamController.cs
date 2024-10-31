using ExamSoft.Application.IRepository.Base;
using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.ExamRequest;
using ExamSoft.Application.Response;
using ExamSoft.Domain.Entities;
using ExamSoft.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamSoft.Presentation.Controllers;


public class ExamController : Controller
{
    private readonly IExamService _examService;
    private readonly IBaseRepository<Student> _studentRepository;
    private readonly IBaseRepository<Lesson> _lessonRepository;

    public ExamController(IExamService examService, IBaseRepository<Student> studentRepository, IBaseRepository<Lesson> lessonRepository)
    {
        _examService = examService;
        _studentRepository = studentRepository;
        _lessonRepository = lessonRepository;
    }

    public IActionResult Index()
    {
        ExamListViewModel model = new ExamListViewModel();
        model.List = _examService.GetExams();
        return View(model);
    }
    
    public IActionResult Delete(int id)
    {
        BaseResponse response = new BaseResponse();
        try
        {
            bool result = _examService.DeleteExam(id);
        }
        catch (Exception e)
        {
            response.SetError(e.Message);
            return Json(response);
        }
        response.SetSuccess("Silindi", null);
        return Json(response);
    }
    [HttpGet]
    public IActionResult AddOrEdit(int id)
    {
        UpdateExamRequest model =_examService.GetExamRequest(id);
        return View("ExamPartial/_form",model);
    }
    [HttpPost]
    public IActionResult AddOrEdit(UpdateExamRequest request)
    {
        BaseResponse response = new BaseResponse();
        request.Lesson = _lessonRepository.Find(x => x.Code.Value == request.LessonCode).FirstOrDefault();
        request.Student = _studentRepository.Find(x => x.Number == request.StudentNumber).FirstOrDefault();
        var validationResult = request.Validate(new UpdateExamRequestValidation());
        if (validationResult.IsValid)
        {
            _examService.UpdateExam(request);
            response.SetSuccess("Elave Olundu", null);
            return Json(response);
        }
        else
        {
            response.SetError(validationResult.Errors.FirstOrDefault().ErrorMessage);
            return Json(response);
        }
    }
    
    
    
}