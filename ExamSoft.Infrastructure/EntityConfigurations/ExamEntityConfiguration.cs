using ExamSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamSoft.Infrastructure.EntityConfigurations;

public class ExamEntityConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasQueryFilter(x => !x.Deleted && x.Active);
    }
}