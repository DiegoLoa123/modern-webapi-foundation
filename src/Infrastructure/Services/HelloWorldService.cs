using ProyPruebasApi.src.Application.Contracts;
using ProyPruebasApi.src.Application.Interfaces;

namespace ProyPruebasApi.src.Infrastructure.Services;

public sealed class HelloWorldService : IHelloWorldService
{
    public HelloWorldResponse CreateGreeting() =>
        new("¡Hola Mundo!", DateTimeOffset.UtcNow);
}
