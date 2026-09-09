using ProyPruebasApi.Application.Interfaces;

namespace ProyPruebasApi.Api.Endpoints;

public static class WeatherEndpoints
{
    public static IEndpointRouteBuilder MapWeatherEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/weatherforecast", (IWeatherForecastService service) =>
                Results.Ok(service.GetForecast()))
            .WithName("GetWeatherForecast")
            .WithSummary("Devuelve el pronóstico meteorológico")
            .Produces(StatusCodes.Status200OK);

        return endpoints;
    }
}
