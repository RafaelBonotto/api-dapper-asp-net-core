using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using System.Threading.Tasks;

namespace Comercio.Services.Services
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public Task<dynamic> ObterSetor()
        {
            try
            {
                return _setorRepository.ObterSetor();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<Setor> ObterSetorPorId(int id)
        {
            try
            {
                return _setorRepository.ObterSetorPorId(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
