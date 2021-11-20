using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace Comercio.Data.ConnectionManager
{
    public class MySqlConnectionManager : IMySqlConnectionManager
    {
        private readonly string _connectionString;

        public MySqlConnectionManager()
        {
            _connectionString = "";// RepositoryBase.stringConnection; 
        }

        public async Task<MySqlConnection> GetConnectionAsync()
        {            
            try
            {
                MySqlConnection connection = new MySqlConnection(_connectionString);                
                                                                        
                await connection.OpenAsync();

                return connection;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
