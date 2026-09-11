namespace ProyPruebasApi.src.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public decimal PriceWithTax => Price * (1m + 0.16m + 0.02m);
}