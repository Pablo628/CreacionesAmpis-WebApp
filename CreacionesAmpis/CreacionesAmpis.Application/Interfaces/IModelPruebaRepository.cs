using CreacionesAmpis.Domain.Entities;

namespace CreacionesAmpis.Application.Interfaces
{
    public interface IModelPruebaRepository
    {
        Task<IEnumerable<ModelPrueba>> GetAllAsync();
        Task<ModelPrueba?> GetByIdAsync(int id);
        Task<ModelPrueba> CreateAsync(ModelPrueba entity);
        Task<bool> UpdateAsync(ModelPrueba entity);
        Task<bool> DeleteAsync(int id);
    }
}
