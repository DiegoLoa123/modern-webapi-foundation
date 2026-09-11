using ProyPruebasApi.src.Application.Contracts;
using ProyPruebasApi.src.Application.Interfaces;

namespace ProyPruebasApi.src.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/products")
            .WithTags("Products");

        group.MapGet("/", GetAll)
            .WithName("GetAllProducts")
            .WithSummary("Devuelve todos los productos")
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/active", GetAllActive)
            .WithName("GetAllActiveProducts")
            .WithSummary("Devuelve todos los productos activos o inactivos según el parámetro")
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/{id:int}", GetById)
            .WithName("GetProductById")
            .WithSummary("Devuelve un producto por ID")
            .Produces<ProductResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", Create)
            .WithName("CreateProduct")
            .WithSummary("Crea un producto")
            .Produces<ProductResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        group.MapPut("/{id:int}", Update)
            .WithName("UpdateProduct")
            .WithSummary("Actualiza un producto")
            .Produces<ProductResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id:int}", Delete)
            .WithName("DeleteProduct")
            .WithSummary("Elimina un producto")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);    
        
        return endpoints;
    }

    private static IResult GetAll(IProductService service)
    {
        return Results.Ok(service.GetAll());
    }

    private static IResult GetAllActive(IProductService service)
    {
        return Results.Ok(service.GetAllActive());
    }

    private static IResult GetById(
        int id,
        IProductService service)
    {
        var product = service.GetById(id);

        return product is null
            ? Results.NotFound()
            : Results.Ok(product);
    }

    private static IResult Create(
        CreateProductRequest request,
        IProductService service)
    {
        var validationResult = Validate(
            request.Name,
            request.Price);

        if (validationResult is not null)
        {
            return validationResult;
        }

        var product = service.Create(request);

        return Results.Created(
            $"/api/products/{product.Id}",
            product);
    }

    private static IResult Update(
        int id,
        UpdateProductRequest request,
        IProductService service)
    {
        var validationResult = Validate(
            request.Name,
            request.Price);

        if (validationResult is not null)
        {
            return validationResult;
        }

        var product = service.Update(id, request);

        return product is null
            ? Results.NotFound()
            : Results.Ok(product);
    }

    private static IResult Delete(
        int id,
        IProductService service)
    {
        var deleted = service.Delete(id);

        return deleted
            ? Results.NoContent()
            : Results.NotFound();
    }

    private static IResult? Validate(
        string? name,
        decimal price)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(name))
        {
            errors["name"] =
                ["El nombre es obligatorio."];
        }
        else if (name.Length < 3)
        {
            errors["name"] =
                ["El nombre debe tener al menos 3 caracteres."];
        }

        if (price <= 0)
        {
            errors["price"] =
                ["El precio debe ser mayor que cero."];
        }

        return errors.Count == 0
            ? null
            : Results.ValidationProblem(errors);
    }
}