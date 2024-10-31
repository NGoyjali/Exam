namespace ExamSoft.Application.Response;

public class BaseResponse
{
    public string Title { get; set; } = "Uğurlu";
    public string Text { get; set; }
    public string Icon { get; set; } = "success";
    public bool Success { get; set; } = true;
    public object Data { get; set; }

    public void SetError(string message)
    {
        Title = "Xəta";
        Icon = "error";    
        Text = message;
        Data = null;
        Success = false;
    }
    
    public void SetSuccess(string message, object data)
    {
        Text = message;
        Data = data;
    }
}