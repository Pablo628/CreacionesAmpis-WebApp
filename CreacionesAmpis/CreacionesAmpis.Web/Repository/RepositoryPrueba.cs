using Dapper;
using System.Data;
using CreacionesAmpis.Web.Models;

namespace CreacionesAmpis.Web.Repository;

public class RepositoryPrueba
{
    private readonly IDbConnection _db;

    public RepositoryPrueba(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<ModelPrueba>> GetAllAsync()
    {
        return await _db.QueryAsync<ModelPrueba>("SELECT * FROM Usuarios");
    }

    public async Task<ModelPrueba?> GetByIdAsync(int id)
    {
        return await _db.QueryFirstOrDefaultAsync<ModelPrueba>(
            "SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
    }
}