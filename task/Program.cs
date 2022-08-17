using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Repositories;
using task.DTO;
using task.Models;
using task.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddControllers();
builder.Services.AddDbContext<SchoolContext>(options => {
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TeacherService>();
builder.Services.AddTransient<ICourse,CourseService>();
builder.Services.AddTransient<StudentService>();
builder.Services.AddTransient<GroupService>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Group>, GroupRepository>();
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
