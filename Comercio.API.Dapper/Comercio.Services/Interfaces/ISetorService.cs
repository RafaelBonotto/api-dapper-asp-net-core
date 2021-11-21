using Comercio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comercio.Services.Interfaces
{
    public interface ISetorService
    {
        Task<List<Setor>> ObterSetor();
        Task<Setor> ObterSetorPorId(int id);
    }
}
