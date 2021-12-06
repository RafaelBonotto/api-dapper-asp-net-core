using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Services.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ResponseBase<List<Produto>>> ObterProdutos();
        Task<ResponseBase<Produto>> ObterPorId(long id);
        Task<ResponseBase<Produto>> InserirProduto(ProdutoRequest produto);
        Task<ResponseBase<Produto>> AtualizarProduto(long id, ProdutoRequest produto);
        Task<ResponseBase<bool>> ExcluirProduto(long id);
    }
}
