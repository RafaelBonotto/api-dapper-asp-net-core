using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMySqlConnectionManager _connection;

        public ProdutoRepository(IMySqlConnectionManager connection)
        {
            _connection = connection;
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            List<Produto> produtos;

            using (var connection = await _connection.GetConnectionAsync())
            {
                produtos =  connection.Query<Produto>(ProdutoQuery.SELECT_PRODUTOS).ToList();
            }

            return produtos;
        }

        public async Task<Produto> ObterPorId(int id)
        {
            Produto produto;

            using (var connection = await _connection.GetConnectionAsync())
            {
                produto = await connection.QueryFirstOrDefaultAsync<Produto>(ProdutoQuery.SELECT_PRODUTO_POR_ID, new { Id = id });
            }

            return produto;
        }
    }
}
