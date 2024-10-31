using System.Linq.Expressions;
using ExamSoft.Application.IRepository.Base;
using ExamSoft.Domain.Complex;
using ExamSoft.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ExamSoft.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where  T : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _table;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = dbContext.Set<T>();
    }

    public IQueryable<T> GetAll() => _table;

    public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        => _table.Where(filter);

    public T Save(T entity)
    {
        var SavedEntity =  entity.Id == 0
            ? _table.Add(entity)
            : _table.Update(entity);
        _dbContext.SaveChangesAsync().WaitAsync(CancellationToken.None);
        return SavedEntity.Entity;
    }
        
}