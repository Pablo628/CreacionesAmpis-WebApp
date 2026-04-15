using CreacionesAmpis.Application.DTOs;

namespace CreacionesAmpis.Application.Interfaces;

public interface ICategoryQueries
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
}