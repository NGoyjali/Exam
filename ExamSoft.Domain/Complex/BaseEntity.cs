using System.ComponentModel.DataAnnotations;

namespace ExamSoft.Domain.Complex;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    
    public bool Deleted { get; set; }
    public bool Active { get; set; } = true;
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? Updated { get; set; }

    public bool Delete()
    {
        Deleted = true;
        Active = false;
        return true;
    }
}