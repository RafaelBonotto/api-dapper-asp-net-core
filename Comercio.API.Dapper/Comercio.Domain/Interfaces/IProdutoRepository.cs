using Comercio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ListarProdutos();
        Task<Produto> ObterPorId(int id);
        Task<Produto> InserirProduto(Produto produto);
    }
}
