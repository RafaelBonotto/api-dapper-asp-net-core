using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using Comercio.Services.Response;
using System;
using System.Threading.Tasks;

namespace Comercio.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListaProdutoResponse> ObterProdutos()
        {
            var ret = new ListaProdutoResponse();
            try
            {
                ret.Produtos = await _repository.ListarProdutos();
                ret.Sucesso = true;
                ret.Mensagem = "Sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }

        public async Task<ProdutoResponse> ObterPorId(long id)
        {
            var ret = new ProdutoResponse();
            try
            {
                ret.Produto = await _repository.ObterPorId(id);
                ret.Sucesso = true;
                ret.Mensagem = "Sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }

        public async Task<ProdutoResponse> InserirProduto(ProdutoRequest produto)
        {
            var ret = new ProdutoResponse();
            try
            {
                var novoProduto = new Produto()
                {
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Preco_custo = produto.Preco_custo,
                    Preco_venda = produto.Preco_venda,
                    Setor_id = produto.Setor_id
                };
                novoProduto = await _repository.InserirProduto(novoProduto);
                ret.Produto = novoProduto;
                ret.Sucesso = true;
                ret.Mensagem = "Produto inserido com sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }

        public async Task<ProdutoResponse> AtualizarProduto(long produtoId, ProdutoRequest produto)
        {
            var ret = new ProdutoResponse();
            try
            {
                var produtoAtualizado = new Produto()
                {
                    Id = produtoId,
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Preco_custo = produto.Preco_custo,
                    Preco_venda = produto.Preco_venda,
                    Setor_id = produto.Setor_id
                };
                produtoAtualizado = await _repository.AtualizarProduto(produtoAtualizado);
                ret.Produto = produtoAtualizado;
                ret.Sucesso = true;
                ret.Mensagem = "Produto atualizado com sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }

        public async Task<ProdutoResponse> ExcluirProduto(long produtoId)
        {
            var ret = new ProdutoResponse();
            try
            {
                if(await _repository.ExcluirProduto(produtoId))
                {
                    ret.Produto = null;
                    ret.Sucesso = true;
                    ret.Mensagem = "Produto excluído com sucesso";
                }
                else
                {
                    ret.Produto = null;
                    ret.Sucesso = false;
                    ret.Mensagem = "Não foi possível excluir o produto";
                }
                return ret;
            }
            catch (Exception erro)
            {
                ret.Produto = null;
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }
    }
}
