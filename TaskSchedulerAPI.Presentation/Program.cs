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
    // Veritabaný baðlantýsý
    services.AddDbContext<TaskSchedulerDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    // Core ve Business katmanýndaki servislerin DI'ye eklenmesi
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ITaskService, TaskService>();

    // DataAccess katmanýndaki repository'lerin DI'ye eklenmesi
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ITaskRepository, TaskRepository>();

    // Automapper profilinin eklenmesi
    services.AddAutoMapper(typeof(MappingProfile));

    // FluentValidation'ýn eklenmesi
    services.AddControllers()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>());

    // Serilog gibi diðer kütüphanelerin eklenmesi
    services.AddLogging(loggingBuilder =>
        loggingBuilder.AddSerilog(dispose: true));
}*/
