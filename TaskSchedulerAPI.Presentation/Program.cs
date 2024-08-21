using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "TASK SCHEDULER API",
        Description = "Serefhan Disek Proje"
    });
});

builder.Services.AddDbContext<TaskSchedulerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHangfire(config => config
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>());

builder.Services.AddLogging(LoggingBuilderExtensions => LoggingBuilderExtensions.AddSerilog(dispose: true));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; 
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
BackgroundJob.Enqueue(() => Console.WriteLine("Hanfire ile görev çalýþtýrýldý!"));
BackgroundJob.Schedule(() => Console.WriteLine("30 saniye sonra çalýþacak görev!"), TimeSpan.FromSeconds(30));
RecurringJob.AddOrUpdate("my-recurring-job", () => Console.WriteLine("Her dakika çalýþacak görev!"), Cron.Minutely);
var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Ýlk görev!"));
BackgroundJob.ContinueWith(jobId, () => Console.WriteLine("Devam eden görev!"));

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

