using FluentValidation;
using FluentValidation.Results;

namespace ExamSoft.Application.Requests;

public abstract class BaseRequest<T> where T :  BaseValidate , new()
{
    protected bool validatinResult;
    public abstract ValidationResult Validate(T obj);
    
}

public interface BaseValidate
{
}