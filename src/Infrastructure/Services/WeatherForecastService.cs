using ProyPruebasApi.src.Application.Contracts;
using ProyPruebasApi.src.Application.Interfaces;

namespace ProyPruebasApi.src.Infrastructure.Services;

public sealed class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] _summaries =
    [
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    ];

    public IReadOnlyCollection<WeatherForecastResponse> GetForecast(int days = 5) {
        var data = Enumerable.Range(1, days)
            .Select(index => new WeatherForecastResponse(
                DateOnly.FromDateTime(DateTime.UtcNow.AddDays(index)),
                Random.Shared.Next(-20, 55),
                _summaries[Random.Shared.Next(_summaries.Length)]))
            .ToArray();
        return data;
    }
}
