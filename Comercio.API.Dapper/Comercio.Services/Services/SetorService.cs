using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using Comercio.Services.Response;
using System;
using System.Collections.Generic;
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

        public async Task<SetorResponse> InserirSetor(SetorRequest setor)
        {
            var ret = new SetorResponse();
            try
            {
                var novoSetor = new Setor(){ Descricao = setor.Descricao };

                await _setorRepository.InserirSetor(novoSetor);
                ret.Setor = novoSetor;
                ret.Sucesso = true;
                ret.Mensagem = "Setor inserido com sucesso";
                return ret;
            }
            catch (Exception error)
            {
                ret.Sucesso = false;
                ret.Mensagem = error.Message;
                return ret;
            }
        }

        public Task<List<Setor>> ObterSetor()
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
