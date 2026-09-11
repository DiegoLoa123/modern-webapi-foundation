using ProyPruebasApi.src.Application.Contracts;
using ProyPruebasApi.src.Application.Interfaces;
using ProyPruebasApi.src.Domain.Entities;

namespace ProyPruebasApi.src.Infrastructure.Services;

public sealed class ProductService : IProductService
{
    private readonly List<Product> _products = [
        new() { Id = 1, Name = "Laptop", Price = 3500, Active = true },
        new() { Id = 2, Name = "Mouse", Price = 80, Active = true },
        new() { Id = 3, Name = "Teclado", Price = 150, Active = true },
        new() { Id = 4, Name = "Monitor", Price = 900, Active = false },
        new() { Id = 5, Name = "Audífonos", Price = 250, Active = true }
    ];

    public IReadOnlyCollection<ProductResponse> GetAll() {
        return _products.Select(ToResponse).ToArray();
    }

    public IReadOnlyCollection<ProductResponse> GetAllActive() {
        return _products.Where(p => p.Active).Select(ToResponse).ToArray();
    }

    public ProductResponse? GetById(int id) {
        var product = _products
            .FirstOrDefault(p => p.Id == id);

        return product is null
            ? null
            : ToResponse(product);
    }

    public ProductResponse Create(CreateProductRequest req) {
        var product = new Product {
            Id = GetNextId(),
            Name = req.Name.Trim(),
            Price = req.Price,
            Active = req.Active
        };

        _products.Add(product);

        return ToResponse(product);
    }

    public ProductResponse? Update(int id, UpdateProductRequest req) {
        var product = _products
            .FirstOrDefault(p => p.Id == id);

        if (product is null) return null;

        product.Name = req.Name.Trim();
        product.Price = req.Price;
        product.Active = req.Active;

        return ToResponse(product);
    }

    public bool Delete(int id) {
        var product = _products
            .FirstOrDefault(p => p.Id == id);

        if (product is null) return false;

        return _products.Remove(product);
    }



    private int GetNextId() {
        return _products.Count == 0
            ? 1
            : _products.Max(p => p.Id) + 1;
    }

    private static ProductResponse ToResponse(Product product)
    {
        return new ProductResponse(
            product.Id,
            product.Name,
            product.Price,
            product.Active
        );
    }
}
