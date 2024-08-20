using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using TaskSchedulerAPI.Business.Interfaces;
using TaskSchedulerAPI.Business.MappingProfiles;
using TaskSchedulerAPI.Business.Services;
using TaskSchedulerAPI.Core.DTOs;
using TaskSchedulerAPI.DataAccess;
using TaskSchedulerAPI.DataAccess.Interfaces;
using TaskSchedulerAPI.DataAccess.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskSchedulerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>());

/*builder.Services.AddLogging(LoggingBuilderExtensions => LoggingBuilderExtensions.AddSerilog(dispose: true));*/

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*public void ConfigureServices(IServiceCollection services)
{



    // Serilog gibi diðer kütüphanelerin eklenmesi
    services.AddLogging(loggingBuilder =>
        loggingBuilder.AddSerilog(dispose: true));
}*/
