namespace ProyPruebasApi.src.Application.Contracts;

public sealed record CreateProductRequest(
    string Name,
    decimal Price,
    bool Active
);