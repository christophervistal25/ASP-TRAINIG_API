using Microsoft.EntityFrameworkCore;
using StudentSIS.API.Contracts;
using StudentSIS.API.DatabaseContext;
using StudentSIS.API.Mapper;
using StudentSIS.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentMapper, StudentMapper>();

builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
