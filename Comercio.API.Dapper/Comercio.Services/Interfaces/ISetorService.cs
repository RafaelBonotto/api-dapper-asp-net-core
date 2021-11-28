using Comercio.Domain.Entities;
using Comercio.Services.Request;
using Comercio.Services.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface ISetorService
    {
        Task<List<Setor>> ObterSetor();
        Task<Setor> ObterSetorPorId(long id);
        Task<SetorResponse> InserirSetor(SetorRequest setor);
        Task<SetorResponse> ExcluirSetor(long setorId);
        Task<SetorResponse> AtualizarSetor(long setorId, SetorRequest setor);
    }
}
