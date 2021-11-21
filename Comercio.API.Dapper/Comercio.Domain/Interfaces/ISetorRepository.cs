using Comercio.Domain.Entities;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface ISetorRepository
    {
        Task<dynamic> ObterSetor();
        Task<Setor> ObterSetorPorId(int id);
    }
}
