using ProyPruebasApi.src.Application.Interfaces;

namespace ProyPruebasApi.src.Api.Endpoints;

public static class HelloWorldEndpoints
{
    public static IEndpointRouteBuilder MapHelloWorldEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/hello", (IHelloWorldService service) =>
                Results.Ok(service.CreateGreeting()))
            .WithName("GetHelloWorld")
            .WithSummary("Devuelve un saludo de la API")
            .Produces(StatusCodes.Status200OK);

        return endpoints;
    }
}
