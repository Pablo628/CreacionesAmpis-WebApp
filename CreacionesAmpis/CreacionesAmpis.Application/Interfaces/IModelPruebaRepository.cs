using CreacionesAmpis.Domain.Entities;

namespace CreacionesAmpis.Application.Interfaces
{
    public interface IModelPruebaRepository
    {
        Task<IEnumerable<ModelPrueba>> GetAllAsync();
        Task<ModelPrueba?> GetByIdAsync(int id);
    }
}
