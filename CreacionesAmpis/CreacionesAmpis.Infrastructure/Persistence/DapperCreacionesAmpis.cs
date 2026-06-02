using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace CreacionesAmpis.Infrastructure.Persistence
{
    public class DapperCreacionesAmpis : IDapperCreacionesAmpis
    {
        private readonly IDbConnection _db;

        public DapperCreacionesAmpis(IDbConnection db)
        {
            _db = db;
        }

        public DbConnection GetDbconnection() => (DbConnection)_db;

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            => _db.QueryFirstOrDefault<T>(sp, parms, commandType: commandType)!;

        public List<T> GetAll<T>(string sp, DynamicParameters parms, int? commandTimeOut = null, CommandType commandType = CommandType.StoredProcedure)
            => _db.Query<T>(sp, parms, commandType: commandType, commandTimeout: commandTimeOut).ToList();

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            => _db.Execute(sp, parms, commandType: commandType);

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            => _db.QueryFirstOrDefault<T>(sp, parms, commandType: commandType)!;

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            => _db.QueryFirstOrDefault<T>(sp, parms, commandType: commandType)!;

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text)
            => await _db.QueryAsync<T>(sql, param, commandType: commandType);

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text)
            => await _db.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);

        public async Task<T> QueryFirstAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text)
            => await _db.QueryFirstAsync<T>(sql, param, commandType: commandType);

        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.Text)
            => await _db.ExecuteAsync(sql, param, commandType: commandType);

        public void Dispose() => _db?.Dispose();
    }
}
