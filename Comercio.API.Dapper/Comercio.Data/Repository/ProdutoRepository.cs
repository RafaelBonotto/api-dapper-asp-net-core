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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _config;
        private string _connectionString;

        public ProdutoRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetSection("ConnectionStrings:comercioDB").Value;
        }

        public async Task<dynamic> ListarProdutos()
        {
            List<Produto> produtos;

            using (var connection = new MySqlConnection(_connectionString))
            {
                produtos = connection.Query<Produto>(ProdutoQuery.SELECT_PRODUTOS).ToList();
            }

            return produtos;
        }
    }
}
