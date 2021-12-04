using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
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

        public async Task<ResponseBase<Setor>> InserirSetor(SetorRequest setor)
        {
            try
            {
                var novoSetor = new Setor() { Descricao = setor.Descricao };
                novoSetor = await _setorRepository.InserirSetor(novoSetor);
                return new ResponseBase<Setor>(novoSetor);
            }
            catch (Exception erro)
            {
                return new ResponseBase<Setor>(erro.Message);
            }
        }

        public async Task<ResponseBase<List<Setor>>> ObterSetor()
        {            
            try
            {
                var setor = await _setorRepository.ObterSetor();
                return new ResponseBase<List<Setor>>(setor);                
            }
            catch (Exception erro)
            {
                return new ResponseBase<List<Setor>>(erro.Message);
            }
        }

        public async Task<ResponseBase<Setor>> ObterSetorPorId(long id)
        {
            try
            {
                var setor = await _setorRepository.ObterSetorPorId(id);
                return new ResponseBase<Setor>(setor);                
            }
            catch (Exception erro)
            {
                return new ResponseBase<Setor>(erro.Message);
            }
        }

        public async Task<ResponseBase<Setor>> AtualizarSetor(long setorId, SetorRequest setor)
        {            
            try
            {
                var setorAtualizado = new Setor() { Id = setorId, Descricao = setor.Descricao };
                setorAtualizado = await _setorRepository.AtualizarSetor(setorAtualizado);
                return new ResponseBase<Setor>(setorAtualizado);               
            }
            catch (Exception erro)
            {
                return new ResponseBase<Setor>(erro.Message);
            }
        }

        public async Task<ResponseBase<bool>> ExcluirSetor(long setorId)
        {
            try
            {
                var sucesso = await _setorRepository.ExcluirSetor(setorId);
                return new ResponseBase<bool>(sucesso);
            }
            catch (Exception erro)
            {
                return new ResponseBase<bool>(erro.Message);
            }
        }
    }
}
