using System.Collections.Generic;
using System.Threading.Tasks;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Entities;
using CreacionesAmpis.Infrastructure.Persistence;
using System.Data;

namespace CreacionesAmpis.Infrastructure.Repositories
{
    public class ModelPruebaRepository : IModelPruebaRepository
    {
        private readonly IDapperCreacionesAmpis _dapper;

        public ModelPruebaRepository(IDapperCreacionesAmpis dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<ModelPrueba>> GetAllAsync()
            => await _dapper.QueryAsync<ModelPrueba>("SELECT * FROM usuarios");

        public async Task<ModelPrueba?> GetByIdAsync(int id)
            => await _dapper.QueryFirstOrDefaultAsync<ModelPrueba>(
                "SELECT * FROM usuarios WHERE Id = @Id", new { Id = id });

        public async Task<ModelPrueba> CreateAsync(ModelPrueba entity)
        {
            const string sql = @"
                INSERT INTO usuarios (Nombre, Email, Contrasena, Rol, Activo, FechaCreacion)
                VALUES (@Nombre, @Email, @Contrasena, @Rol, @Activo, @FechaCreacion);
                SELECT * FROM usuarios WHERE Id = LAST_INSERT_ID();";

            return await _dapper.QueryFirstAsync<ModelPrueba>(sql, entity);
        }

        public async Task<bool> UpdateAsync(ModelPrueba entity)
        {
            const string sql = @"
                UPDATE usuarios
                SET Nombre = @Nombre, Email = @Email, Rol = @Rol, Activo = @Activo
                WHERE Id = @Id";

            var rows = await _dapper.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rows = await _dapper.ExecuteAsync(
                "DELETE FROM usuarios WHERE Id = @Id", new { Id = id });
            return rows > 0;
        }
    }
}