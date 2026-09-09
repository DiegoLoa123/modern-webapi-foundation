using ProyPruebasApi.Api.Endpoints;
using ProyPruebasApi.Application.Interfaces;
using ProyPruebasApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IHelloWorldService, HelloWorldService>();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapHelloWorldEndpoints();
app.MapWeatherEndpoints();

app.Run();

public partial class Program { }
