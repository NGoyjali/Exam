using ExamSoft.Application.IService;
using ExamSoft.Application.Requests.StudentRequest;
using ExamSoft.Application.Response;
using ExamSoft.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamSoft.Presentation.Controllers;


public class StudentController : Controller
{
    private readonly IStudentService studentService;

    public StudentController(IStudentService studentService)
    {
        this.studentService = studentService;
    }

    public IActionResult Index()
    {
        StudentListViewModel model = new StudentListViewModel();
        model.List = studentService.GetStudents();
        return View(model);
    }
    
    public IActionResult Delete(int id)
    {
        BaseResponse response = new BaseResponse();
        try
        {
            bool result = studentService.DeleteStudent(id);
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
        UpdateStudentRequest model =studentService.GetStudentRequest(id);
        return View("StudentPartial/_form",model);
    }
    
    [HttpPost]
    public IActionResult AddOrEdit(UpdateStudentRequest request)
    {
        BaseResponse response = new BaseResponse();
        var validationResult = request.Validate(new UpdateStudentRequestValidation());
        if (validationResult.IsValid)
        {
            studentService.UpdateStudent(request);
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