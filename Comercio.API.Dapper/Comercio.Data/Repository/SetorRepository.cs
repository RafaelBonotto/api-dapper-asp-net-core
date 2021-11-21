using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public class SetorRepository : ISetorRepository
    {
        private readonly IConfiguration _config;
        private string _connectionString;

        public SetorRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetSection("ConnectionStrings:comercioDB").Value;
        }
        public async Task<dynamic> ObterSetor()
        {
            List<Setor> setorBanco;

            using (var connection = new MySqlConnection(_connectionString))
            {
                setorBanco = connection.Query<Setor>(SetorQuery.SELECT_SETOR).ToList();
            }

            return setorBanco;
        }

        public async Task<Setor> ObterSetorPorId(int id)
        {
            Setor setorBanco;

            using (var connection = new MySqlConnection(_connectionString))
            {
                setorBanco = connection.QueryFirstOrDefault<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = id });
            }

            return setorBanco;
        }
    }
}