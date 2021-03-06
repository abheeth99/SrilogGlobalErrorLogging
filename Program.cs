using Serilog;
using SrilogGlobalErrorLogging.Middlewares;
using SrilogGlobalErrorLogging.Services.WeatherService;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //DI
    builder.Services.AddScoped<IWeatherService, WeatherService>();

    //ApplicationInsights
    builder.Services.AddApplicationInsightsTelemetry();

    // Serilog
    builder.Host.UseSerilog((ctx, lc) => lc
        
        .ReadFrom.Configuration(ctx.Configuration));

    var app = builder.Build();

    // Serilog
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    //app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
