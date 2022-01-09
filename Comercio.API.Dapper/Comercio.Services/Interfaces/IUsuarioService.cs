using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Services.Request;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface IUsuarioService
    {        
        Task<ResponseBase<Usuario>> Regsitrar(UsuarioRequest usuario);
        //Task<ResponseBase<Usuario>> Login();
        Task<ResponseBase<string>> Login(LoginRequest loginRequest);
    }
}
