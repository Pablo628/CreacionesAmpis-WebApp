using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Exceptions;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Entities;
using CreacionesAmpis.Domain.Interfaces;

namespace CreacionesAmpis.Application.Commands.Products;

public class ProductCommands : IProductCommands
{
    private readonly IProductRepository _repo;

    public ProductCommands(IProductRepository repo) => _repo = repo;

    public async Task<int> CreateAsync(ProductDto dto)
    {
        var entity = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            CategoryId = dto.CategoryId
        };

        await _repo.AddAsync(entity);
        return entity.Id;
    }

    public async Task UpdateAsync(ProductDto dto)
    {
        var existing = await _repo.GetByIdAsync(dto.Id);
        if (existing is null) throw new NotFoundException($"Producto con id {dto.Id} no existe.");

        existing.Name = dto.Name;
        existing.Description = dto.Description;
        existing.Price = dto.Price;
        existing.Stock = dto.Stock;
        existing.CategoryId = dto.CategoryId;

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) throw new NotFoundException($"Producto con id {id} no existe.");

        await _repo.DeleteAsync(existing);
    }
}