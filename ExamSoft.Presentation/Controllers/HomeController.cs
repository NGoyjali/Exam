using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.LessonRequest;
using ExamSoft.Application.Response;
using Microsoft.AspNetCore.Mvc;
using ExamSoft.Presentation.ViewModels;

namespace ExamSoft.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILessonService _lessonService;

    public HomeController(ILogger<HomeController> logger, ILessonService lessonService)
    {
        _logger = logger;
        _lessonService = lessonService;
    }

    public IActionResult Index()
    {
        LessonListViewModel model = new LessonListViewModel();
        model.List = _lessonService.GetLessons();
        return View(model);
    }
    
    public IActionResult Delete(int id)
    {
        BaseResponse response = new BaseResponse();
        try
        {
            bool result = _lessonService.DeleteLesson(id);
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
        UpdateLessonRequest model =_lessonService.GetLessonRequest(id);
        return View("Partial/_Form",model);
    }
    [HttpPost]
    public IActionResult AddOrEdit(UpdateLessonRequest request)
    {
        BaseResponse response = new BaseResponse();
        var validationResult = request.Validate(new UpdateLessonRequestValidation());
        if (validationResult.IsValid)
        {
            _lessonService.UpdateLesson(request);
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