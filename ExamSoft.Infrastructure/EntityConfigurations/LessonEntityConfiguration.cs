using ExamSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamSoft.Infrastructure.EntityConfigurations;

public class LessonEntityConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ComplexProperty(x => x.Code)
            .Property(x => x.Value)
            .IsUnicode()
            .HasColumnName("Code");


        builder.OwnsOne(x => x.Teacher, z =>
        {
            z.Property(x => x.Name).IsRequired()
                .HasMaxLength(20)
                .HasColumnName("TeacherName");
            
            z.Property(x => x.Surname).IsRequired()
                .HasMaxLength(20)
                .HasColumnName("TeacherSurname");
        });

        builder.HasMany(x => x.Exams)
            .WithOne(x => x.Lesson)
            .HasForeignKey(x => x.LessonId);

        builder.HasQueryFilter(x => !x.Deleted && x.Active);
        
    }
}