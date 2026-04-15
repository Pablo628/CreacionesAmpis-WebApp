using CreacionesAmpis.Application.DTOs;

namespace CreacionesAmpis.Application.Interfaces;

public interface ICategoryCommands
{
    Task<int> CreateAsync(CategoryDto dto);
    Task UpdateAsync(CategoryDto dto);
    Task DeleteAsync(int id);
}