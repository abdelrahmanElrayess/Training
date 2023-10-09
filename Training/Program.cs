using Microsoft.EntityFrameworkCore;
using Training.Data;
using Serilog;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Training.Services;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting up");
    var builder = WebApplication.CreateBuilder(args);

    var configuration = new ConfigurationBuilder()
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .Build();
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddDbContext<TrelloContext>(options => options.UseInMemoryDatabase("TrainingContext"));
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<ITrelloTaskJobTestService, TrelloTaskTestService>();
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddHangfire(x =>
    {
        x.UseSqlServerStorage(configuration.GetConnectionString("DBConnection"));
    });
    builder.Services.AddHangfireServer();
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

    app.UseHangfireDashboard();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}


