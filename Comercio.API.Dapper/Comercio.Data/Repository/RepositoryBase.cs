using Comercio.Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public abstract class RepositoryBase : IRepositoryBase
    {
        private readonly IConfiguration _config;
        private string _connectionString;

        public RepositoryBase(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetSection("ConnectionStrings:comercioDB").Value;
        }

        public async Task<dynamic> Query(string sql = null, object obj = null)
        {

            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryAsync<dynamic>(sql, obj);
            }
        }

        public async Task<dynamic> Add(string sql, object obj)
        {
            return await Query(sql, obj);
        }

        public async Task<bool> Delete(string sql, object obj)
        {
            await Query(sql, obj);
            return true;
        }

        public async Task<dynamic> GetAll(string sql)
        {
            return await Query(sql);
        }

        public async Task<dynamic> GetById(string sql, object obj)
        {
            return await Query(sql, obj);
        }

        public async Task<dynamic> Update(string sql, object obj)
        {
            return await Query(sql, obj);
        }
    }
}
