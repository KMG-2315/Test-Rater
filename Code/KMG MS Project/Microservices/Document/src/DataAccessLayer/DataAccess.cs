using Dapper;
using DataAccessLayer;
using Document.DataAccessLayer.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Document.DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        private readonly DapperContext _context;

        public DataAccess(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using var connection = _context.CreateConnection();
            //return await connection.QueryAsync<T>(sql, parameters);
            return await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.Text);

        }

        public async Task<T> QuerySingleAsync<T>(string sql, object parameters = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using var connection = _context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
