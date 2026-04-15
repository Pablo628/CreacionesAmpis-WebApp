using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Exceptions;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Interfaces;

namespace CreacionesAmpis.Application.Queries.Categories;

public class CategoryQueries : ICategoryQueries
{
    private readonly ICategoryRepository _repo;

    public CategoryQueries(ICategoryRepository repo) => _repo = repo;

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();
        return categories
            .Select(c => new CategoryDto(c.Id, c.Name))
            .ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        if (c is null)
            throw new NotFoundException($"Categoría con id {id} no existe.");

        return new CategoryDto(c.Id, c.Name);
    }
}
``