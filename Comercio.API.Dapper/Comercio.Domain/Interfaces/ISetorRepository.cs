using Comercio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Domain.Interfaces
{
    public interface ISetorRepository
    {
        Task<List<Setor>> ObterSetor();
        Task<Setor> ObterSetorPorId(int id);
    }
}
