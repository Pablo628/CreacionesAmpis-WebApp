using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Exceptions;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Interfaces;

namespace CreacionesAmpis.Application.Queries.Products;

public class ProductQueries : IProductQueries
{
    private readonly IProductRepository _repo;

    public ProductQueries(IProductRepository repo) => _repo = repo;

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return products.Select(p => new ProductDto(
            p.Id, p.Name, p.Description, p.Price, p.Stock, p.CategoryId
        )).ToList();
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var p = await _repo.GetByIdAsync(id);
        if (p is null) throw new NotFoundException($"Producto con id {id} no existe.");

        return new ProductDto(p.Id, p.Name, p.Description, p.Price, p.Stock, p.CategoryId);
    }
}