using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Services.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface ISetorService
    {
        Task<ResponseBase<List<Setor>>> ObterSetor();
        Task<ResponseBase<Setor>> ObterSetorPorId(long id);
        Task<ResponseBase<Setor>> InserirSetor(SetorRequest setor);
        Task<ResponseBase<bool>> ExcluirSetor(long setorId);
        Task<ResponseBase<Setor>> AtualizarSetor(long setorId, SetorRequest setor);
    }
}
