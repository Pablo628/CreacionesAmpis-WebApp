using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Exceptions;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Entities;
using CreacionesAmpis.Domain.Interfaces;

namespace CreacionesAmpis.Application.Commands.Categories;

public class CategoryCommands : ICategoryCommands
{
    private readonly ICategoryRepository _repo;

    public CategoryCommands(ICategoryRepository repo) => _repo = repo;

    public async Task<int> CreateAsync(CategoryDto dto)
    {
        var entity = new Category
        {
            Name = dto.Name
        };

        await _repo.AddAsync(entity);
        return entity.Id;
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var existing = await _repo.GetByIdAsync(dto.Id);
        if (existing is null)
            throw new NotFoundException($"Categoría con id {dto.Id} no existe.");

        existing.Name = dto.Name;

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null)
            throw new NotFoundException($"Categoría con id {id} no existe.");

        await _repo.DeleteAsync(existing);
    }
}