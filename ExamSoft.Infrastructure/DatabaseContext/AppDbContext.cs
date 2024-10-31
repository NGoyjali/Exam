using ExamSoft.Domain.Entities;
using ExamSoft.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ExamSoft.Infrastructure.DatabaseContext;

public class AppDbContext : DbContext
{
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StudentEntityConfiguration());
        builder.ApplyConfiguration(new ExamEntityConfiguration());
        builder.ApplyConfiguration(new LessonEntityConfiguration());
    }
}