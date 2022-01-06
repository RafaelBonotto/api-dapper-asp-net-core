using Comercio.Domain.Entities;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<Usuario> Registrar();
    }
}
