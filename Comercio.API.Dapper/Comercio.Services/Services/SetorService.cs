using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using Comercio.Services.Response;
using System;
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
                novoSetor = await _setorRepository.InserirSetor(novoSetor);
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

        public async Task<ListaSetorResponse> ObterSetor()
        {
            var ret = new ListaSetorResponse();
            try
            {
                ret.Setores = await _setorRepository.ObterSetor();
                ret.Sucesso = true;
                ret.Mensagem = "Sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }

        public async Task<SetorResponse> ObterSetorPorId(long id)
        {
            var ret = new SetorResponse();
            try
            {
                ret.Setor = await _setorRepository.ObterSetorPorId(id);
                ret.Sucesso = true;
                ret.Mensagem = "Sucesso";
                return ret;
            }
            catch (Exception erro)
            {
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }
        
        public async Task<SetorResponse> AtualizarSetor(long setorId, SetorRequest setor)
        {
            var ret = new SetorResponse();
            try
            {
                var setorAtualizado = new Setor() { Descricao = setor.Descricao };
                setorAtualizado = await _setorRepository.AtualizarSetor(setorAtualizado);
                ret.Setor = setorAtualizado;
                ret.Sucesso = true;
                ret.Mensagem = "Setor atualizado com sucesso";
                return ret;
            }
            catch (Exception error)
            {
                ret.Sucesso = false;
                ret.Mensagem = error.Message;
                return ret;
            }
        }

        public async Task<SetorResponse> ExcluirSetor(long setorId)
        {
            var ret = new SetorResponse();
            try
            {
                if (await _setorRepository.ExcluirSetor(setorId))
                {
                    ret.Setor = null;
                    ret.Sucesso = true;
                    ret.Mensagem = "Setor excluído com sucesso";
                }
                else
                {
                    ret.Setor = null;
                    ret.Sucesso = false;
                    ret.Mensagem = "Não foi possível excluir o setor";
                }
                return ret;
            }
            catch (Exception erro)
            {
                ret.Setor = null;
                ret.Sucesso = false;
                ret.Mensagem = erro.Message;
                return ret;
            }
        }
    }
}
