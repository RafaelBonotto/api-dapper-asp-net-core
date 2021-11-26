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
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    produtos = connection.Query<Produto>(ProdutoQuery.SELECT_PRODUTOS).ToList();
                }

                return produtos;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<Produto> ObterPorId(long id)
        {
            Produto produto;

            using (var connection = await _connection.GetConnectionAsync())
            {
                produto = await connection.QueryFirstOrDefaultAsync<Produto>(ProdutoQuery.SELECT_PRODUTO_POR_ID, new { Id = id });
                produto.Tb_Setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = produto.Setor_id });
            }
            return produto;
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {            
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    var produtoId = await connection.ExecuteScalarAsync<long>(ProdutoQuery.RetornaQueryInsertProduto(produto));
                    return await this.ObterPorId(produtoId);
                }
            }
            catch (System.Exception e)
            {
                return null;
            }
        }
    }
}
