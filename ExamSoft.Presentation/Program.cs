using ExamSoft.Application.IRepository.Base;
using ExamSoft.Application.IService;
using ExamSoft.Infrastructure.DatabaseContext;
using ExamSoft.Infrastructure.Repository;
using ExamSoft.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
IServiceCollection services = builder.Services;

services.AddDbContext<AppDbContext>(x => 
        x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    );

services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
services.AddScoped<ILessonService,LessonService>();
services.AddScoped<IStudentService,StudentService>();
services.AddScoped<IExamService,ExamService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();