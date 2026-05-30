using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Entities;

namespace CreacionesAmpis.Application.Services
{
    public class ServicePrueba : IServicePrueba
    {
        private readonly IModelPruebaRepository _repository;

        public ServicePrueba(IModelPruebaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ModelPrueba>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<ModelPrueba?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<ModelPrueba> CreateAsync(CreateModelPruebaDTO dto)
        {
            var entity = new ModelPrueba
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contrasena = dto.Contrasena,
                Rol = dto.Rol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateModelPruebaDTO dto)
        {
            var entity = new ModelPrueba
            {
                Id = id,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Rol = dto.Rol,
                Activo = dto.Activo
            };
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}
