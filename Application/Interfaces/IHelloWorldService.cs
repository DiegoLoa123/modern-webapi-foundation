using ProyPruebasApi.Application.Contracts;

namespace ProyPruebasApi.Application.Interfaces;

public interface IHelloWorldService
{
    HelloWorldResponse CreateGreeting();
}
