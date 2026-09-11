namespace ProyPruebasApi.src.Application.Contracts;

public sealed record ProductResponse(
    int Id,
    string Name,
    decimal Price,
    bool Active
)
{
    private const decimal IgvRate = 0.16m;
    private const decimal IpmRate = 0.02m;
    public decimal PriceWithTax => Price * (1m + IgvRate + IpmRate);
}