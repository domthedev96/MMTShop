using System.Data;
using Microsoft.Data.SqlClient;
using MMTShop.Business.Interfaces;

namespace MMTShop.Business.Factories
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;


        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connect()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
