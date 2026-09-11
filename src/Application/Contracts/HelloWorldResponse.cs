namespace ProyPruebasApi.src.Application.Contracts;

public sealed record HelloWorldResponse(
  string Message,
  DateTimeOffset Timestamp
);