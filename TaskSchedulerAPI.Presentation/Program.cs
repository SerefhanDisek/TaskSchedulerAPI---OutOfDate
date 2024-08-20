using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskSchedulerAPI.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskSchedulerDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

/*public void ConfigureServices(IServiceCollection services)
{
    // Veritaban� ba�lant�s�
    services.AddDbContext<TaskSchedulerDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    // Core ve Business katman�ndaki servislerin DI'ye eklenmesi
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ITaskService, TaskService>();

    // DataAccess katman�ndaki repository'lerin DI'ye eklenmesi
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ITaskRepository, TaskRepository>();

    // Automapper profilinin eklenmesi
    services.AddAutoMapper(typeof(MappingProfile));

    // FluentValidation'�n eklenmesi
    services.AddControllers()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>());

    // Serilog gibi di�er k�t�phanelerin eklenmesi
    services.AddLogging(loggingBuilder =>
        loggingBuilder.AddSerilog(dispose: true));
}*/
