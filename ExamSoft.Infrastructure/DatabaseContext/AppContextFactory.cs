using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExamSoft.Infrastructure.DatabaseContext;

public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private string Str = "Data Source= DESKTOP-U995IS2\\MSSQLSERVER22 ; Initial Catalog=ExamDb; integrated security = true; TrustServerCertificate=True; MultipleActiveResultSets = true;";

    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(Str);

        return new AppDbContext(optionsBuilder.Options);
    }
}