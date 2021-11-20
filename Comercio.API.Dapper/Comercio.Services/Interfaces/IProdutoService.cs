using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<dynamic> ObterProdutos();
    }
}
