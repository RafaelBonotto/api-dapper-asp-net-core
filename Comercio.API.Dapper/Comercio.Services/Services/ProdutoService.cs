using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
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

        public async Task<List<Produto>> ObterProdutos()
        {
            try
            {
                return await _repository.ListarProdutos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Produto> ObterPorId(int id)
        {
            try
            {
                return await _repository.ObterPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Produto> InserirProduto(Produto produto)
        {
            try
            {
                return await _repository.InserirProduto(produto);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
