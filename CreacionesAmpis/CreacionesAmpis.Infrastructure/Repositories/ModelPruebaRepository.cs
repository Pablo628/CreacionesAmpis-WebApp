using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Domain.Entities;
using Dapper;
using System.Data;

namespace CreacionesAmpis.Infrastructure.Repositories
{
    public class ModelPruebaRepository : IModelPruebaRepository
    {
        private readonly IDbConnection _db;

        public ModelPruebaRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ModelPrueba>> GetAllAsync()
        {
            return await _db.QueryAsync<ModelPrueba>("SELECT * FROM usuarios");
        }

        public async Task<ModelPrueba?> GetByIdAsync(int id)
        {
            return await _db.QueryFirstOrDefaultAsync<ModelPrueba>(
                "SELECT * FROM usuarios WHERE Id = @Id", new { Id = id });
        }
    }
}
