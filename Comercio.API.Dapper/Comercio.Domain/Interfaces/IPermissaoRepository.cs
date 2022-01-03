using Comercio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface IPermissaoRepository
    {
        Task<List<Permissao>> ObterPermissaoUsuario(long idUsuario);
    }
}
