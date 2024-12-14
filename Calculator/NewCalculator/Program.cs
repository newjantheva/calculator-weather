using NewCalculator.Core.Interfaces;
using NewCalculator.Infrastructure.Logger;
using NewCalculator.Infrastructure.Services;
using NewCalculator.Infrastructure.Services.Calculator;
using NewCalculator.Infrastructure.Services.Weather;
using NewCalculator.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddOptions<WeatherApiKeyOptions>()
            .Bind(builder.Configuration.GetSection(WeatherApiKeyOptions.WeatherApi));


builder.Services.AddSingleton<ILoggerService>(provider => new LoggerService(
[
    new ConsoleLoggerService(),
    new FileLoggerService("Logs/log.txt"),
    new SqlLoggerService(connectionString ?? ""),
]));

builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddHttpClient<IHttpClientService, HttpClientService>();


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
