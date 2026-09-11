namespace ProyPruebasApi.src.Application.Contracts;

public sealed record UpdateProductRequest(
    string Name,
    decimal Price,
    bool Active
);