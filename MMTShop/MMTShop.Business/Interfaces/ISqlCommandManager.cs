using System.Data;
using System.Threading.Tasks;

namespace MMTShop.Business.Interfaces
{
    public interface ISqlCommandManager
    {
        void BuildStoredProc(string storedProcedure, IDbConnection connection);
        Task<DataTable> ExecuteQueryAsync();
        void AddParameter(string name, SqlDbType type, object value);
    }
}
