using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.DataAccessLayer
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        Task<T> QuerySingleAsync<T>(string sql, object parameters = null);
        Task<int> ExecuteAsync(string sql, object parameters = null);
    }
}
