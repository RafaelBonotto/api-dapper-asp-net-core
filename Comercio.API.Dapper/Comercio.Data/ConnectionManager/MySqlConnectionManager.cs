using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace Comercio.Data.ConnectionManager
{
    public class MySqlConnectionManager : IMySqlConnectionManager
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public MySqlConnectionManager(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetSection("ConnectionStrings:comercioDB").Value;
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
