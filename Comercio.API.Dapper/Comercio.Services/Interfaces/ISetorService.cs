using Comercio.Domain.Entities;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface ISetorService
    {
        Task<dynamic> ObterSetor();
        Task<Setor> ObterSetorPorId(int id);
    }
}
