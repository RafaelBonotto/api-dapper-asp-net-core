using Comercio.Domain.Entities;
using Comercio.Services.Request;
using Comercio.Services.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ListaProdutoResponse> ObterProdutos();
        Task<ProdutoResponse> ObterPorId(long id);
        Task<ProdutoResponse> InserirProduto(ProdutoRequest produto);
        Task<ProdutoResponse> AtualizarProduto(long produtoId, ProdutoRequest produto);
        Task<ProdutoResponse> ExcluirProduto(long produtoId);
    }
}
