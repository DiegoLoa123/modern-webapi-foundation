using ProyPruebasApi.Application.Contracts;
using ProyPruebasApi.Application.Interfaces;

namespace ProyPruebasApi.Infrastructure.Services;

public sealed class HelloWorldService : IHelloWorldService
{
    public HelloWorldResponse CreateGreeting() =>
        new("¡Hola Mundo!", DateTimeOffset.UtcNow);
}
