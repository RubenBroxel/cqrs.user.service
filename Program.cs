using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Cqrs.Users.Service;
using Cqrs.Users.Service.Infraestructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional: false, true).AddEnvironmentVariables(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<UsuariosCqrsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceConnection")));

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllers();

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