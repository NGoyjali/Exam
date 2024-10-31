using System.Linq.Expressions;
using ExamSoft.Domain.Complex;

namespace ExamSoft.Application.IRepository.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> Find(Expression<Func<T,bool>> filter);
    T Save(T entity);
}