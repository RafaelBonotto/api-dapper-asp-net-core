using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
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

        public async Task<dynamic> ObterProdutos()
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
    }
}
