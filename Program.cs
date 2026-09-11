using ProyPruebasApi.src.Api.Endpoints;
using ProyPruebasApi.src.Application.Interfaces;
using ProyPruebasApi.src.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IHelloWorldService, HelloWorldService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapHelloWorldEndpoints();
app.MapProductEndpoints();
app.MapWeatherEndpoints();

await app.RunAsync();