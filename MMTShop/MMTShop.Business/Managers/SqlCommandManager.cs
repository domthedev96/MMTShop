using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MMTShop.Business.Interfaces;

namespace MMTShop.Business.Managers
{
    public class SqlCommandManager : ISqlCommandManager
    {
        private SqlCommand _command; //Serves as a host for the parameters to be set

        public SqlCommandManager()
        {
            _command = new SqlCommand();
        }

        public void BuildStoredProc(string StoredProcedure, IDbConnection connection)
        {
            _command.Parameters.Clear();
            _command = new SqlCommand();
            _command.Connection = (SqlConnection)connection;
            _command.CommandText = StoredProcedure;
            _command.CommandType = CommandType.StoredProcedure;
        }

        public async Task<DataTable> ExecuteQueryAsync()
        {
            using (var reader = await _command.ExecuteReaderAsync())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                _command.Dispose();
                return dt;
            }
        }
        public void AddParameter(string name, SqlDbType type, object value)
        {
            _command.Parameters.Add(name, type).Value = value;
        }
    }
}
