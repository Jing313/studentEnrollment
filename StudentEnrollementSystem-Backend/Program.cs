using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentEnrollementSystem_Backend.DB;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("StudentEnrollmentDb")));
//builder.Services.AddDbContext<StudentContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentEnrollmentDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}







app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
