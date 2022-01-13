using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                List<Produto> produtos = connection.Query<Produto>(ProdutoQuery.SELECT_PRODUTOS).ToList();

                if (produtos == null)
                    throw new Exception("Não foi encontrado nenhum produto no sistema");
                      
                foreach (var produto in produtos)
                    produto.Tb_Setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = produto.Setor_id });
                
                return produtos;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Produto> ObterPorId(long id)
        {
            using var connection = await _connection.GetConnectionAsync();
            Produto produto = await connection.QueryFirstOrDefaultAsync<Produto>(ProdutoQuery.SELECT_PRODUTO_POR_ID, new { Id = id });
            if (produto == null)
                throw new Exception("Não foi encontrado nenhum produto no sistema");

            produto.Tb_Setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = produto.Setor_id });
            return produto;
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {            
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                var checkCodigo = await connection.QueryFirstOrDefaultAsync<Produto>(ProdutoQuery.SELECT_PRODUTO_POR_CODIGO, new { Codigo = produto.Codigo });
                if (checkCodigo != null)
                    throw new Exception("Não foi possível inserir o produto com esse código");

                var produtoId = await connection.ExecuteScalarAsync<long>(ProdutoQuery.RetornaQueryInsertProduto(produto));
                return await this.ObterPorId(produtoId);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                await connection.QueryAsync(ProdutoQuery.RetornaQueryUpdateProduto(produto));
                return await this.ObterPorId(produto.Id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExcluirProduto(long id)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                return await connection.QueryAsync<Setor>(ProdutoQuery.DELETE_PRODUTO, new { Id = id }) != null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<bool> TesteTransactionCommitRollback(Produto produto)
        {

            var insertProduto = @$"INSERT INTO comercioDB.tb_produto 
                        (codigo, descricao, preco_custo, preco_venda, data_fabricacao, data_validade, ativo, data_criacao, data_alteracao)
                        VALUES ('{produto.Codigo}', '{produto.Descricao}', {produto.Preco_custo}, {produto.Preco_venda}, now(), now(), 1, now(), now());";
                        
            var insertSetor = @"UPDATE comercioDB.tb_produto SET setor_id = 20;";

            using (var connection = await _connection.GetConnectionAsync())
            {

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(insertProduto, transaction: transaction);   
                        connection.Execute(insertSetor, transaction: transaction);   
                        //await connection.QueryAsync(insertProduto);
                        //await connection.QueryAsync(insertSetor);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception erro)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }              
            }
        }
    }
}
