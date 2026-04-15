using CreacionesAmpis.Application.DTOs;

namespace CreacionesAmpis.Application.Interfaces;

public interface IProductCommands
{
    Task<int> CreateAsync(ProductDto dto);
    Task UpdateAsync(ProductDto dto);
    Task DeleteAsync(int id);
}