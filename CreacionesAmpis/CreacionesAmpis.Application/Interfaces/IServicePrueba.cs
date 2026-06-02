using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Domain.Entities;

namespace CreacionesAmpis.Application.Interfaces
{
    public interface IServicePrueba
    {
        Task<IEnumerable<ModelPrueba>> GetAllAsync();
        Task<ModelPrueba?> GetByIdAsync(int id);
        Task<ModelPrueba> CreateAsync(CreateModelPruebaDTO dto);
        Task<bool> UpdateAsync(int id, UpdateModelPruebaDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
