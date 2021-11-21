using Comercio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> ObterProdutos();

        Task<Produto> ObterPorId(int id);
    }
}
