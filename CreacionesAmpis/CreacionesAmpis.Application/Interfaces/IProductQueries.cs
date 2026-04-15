using CreacionesAmpis.Application.DTOs;

namespace CreacionesAmpis.Application.Interfaces;

public interface IProductQueries
{
    Task<List<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByIdAsync(int id);
}