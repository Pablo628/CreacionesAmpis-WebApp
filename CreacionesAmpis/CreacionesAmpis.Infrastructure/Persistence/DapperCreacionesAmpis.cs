using Dapper;
using System.Data;
using System.Data.Common;

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

        public void Dispose() { }
    }
}
