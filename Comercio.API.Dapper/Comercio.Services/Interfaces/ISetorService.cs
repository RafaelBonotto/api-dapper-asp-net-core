using Comercio.Services.Request;
using Comercio.Services.Response;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface ISetorService
    {
        Task<ListaSetorResponse> ObterSetor();
        Task<SetorResponse> ObterSetorPorId(long id);
        Task<SetorResponse> InserirSetor(SetorRequest setor);
        Task<SetorResponse> ExcluirSetor(long setorId);
        Task<SetorResponse> AtualizarSetor(long setorId, SetorRequest setor);
    }
}
