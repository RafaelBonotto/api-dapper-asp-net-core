using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using System;
using System.Collections.Generic;
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

        public async Task<ResponseBase<List<Produto>>> ObterProdutos()
        {
            try
            {
                var produtos = await _repository.ListarProdutos();
                return new ResponseBase<List<Produto>>(produtos);
            }
            catch (Exception erro)
            {
                return new ResponseBase<List<Produto>>(erro.Message);
            }
        }

        public async Task<ResponseBase<Produto>> ObterPorId(long id)
        {
            try
            {
                var produto = await _repository.ObterPorId(id);
                return new ResponseBase<Produto>(produto);
            }
            catch (Exception erro)
            {
                return new ResponseBase<Produto>(erro.Message);
            }
        }

        public async Task<ResponseBase<Produto>> InserirProduto(ProdutoRequest produto)
        {
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
                return new ResponseBase<Produto>(novoProduto);
            }
            catch (Exception erro)
            {
                return new ResponseBase<Produto>(erro.Message);
            }
        }

        public async Task<ResponseBase<Produto>> AtualizarProduto(long id, ProdutoRequest produto)
        {
            try
            {
                var produtoAtualizado = new Produto()
                {
                    Id = id,
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Preco_custo = produto.Preco_custo,
                    Preco_venda = produto.Preco_venda,
                    Setor_id = produto.Setor_id
                };
                produtoAtualizado = await _repository.AtualizarProduto(produtoAtualizado);
                return new ResponseBase<Produto>(produtoAtualizado);
            }
            catch (Exception erro)
            {
                return new ResponseBase<Produto>(erro.Message);
            }
        }

        public async Task<ResponseBase<bool>> ExcluirProduto(long id)
        {
            try
            {
                var sucesso = await _repository.ExcluirProduto(id);
                return new ResponseBase<bool>(sucesso);
            }
            catch (Exception erro)
            {
                return new ResponseBase<bool>(erro.Message);
            }
        }
    }
}
