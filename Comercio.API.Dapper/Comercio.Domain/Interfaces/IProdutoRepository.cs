using Comercio.Domain.Entities;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<dynamic> ListarProdutos();
    }
}
