using ProyPruebasApi.src.Application.Contracts;

namespace ProyPruebasApi.src.Application.Interfaces;

public interface IProductService
{
  IReadOnlyCollection<ProductResponse> GetAll();
  IReadOnlyCollection<ProductResponse> GetAllActive();
  ProductResponse? GetById(int id);
  ProductResponse Create(CreateProductRequest request);
  ProductResponse? Update(int id, UpdateProductRequest request);
  bool Delete(int id);
}