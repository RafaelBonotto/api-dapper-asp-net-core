using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Comercio.Domain.Services;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using SecureIdentity.Password;
using System;
using System.Threading.Tasks;

namespace Comercio.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly TokenService _tokenService;
        private readonly IUsuarioRepository _repository;
        private readonly IPermissaoRepository _repositoryPermissao;

        public UsuarioService(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<ResponseBase<string>> Login(LoginRequest loginRequest)
        {
            try
            {
                var usuario = await _repository.ObterUsuarioPorEmail(loginRequest.Email);
                usuario.Permissoes = await _repositoryPermissao.ObterPermissaoUsuario(usuario.Id);

                if (!PasswordHasher.Verify(usuario.Senha, loginRequest.Senha))
                    return new ResponseBase<string>(error: "Usuário ou senha inválidos");

                var token = _tokenService.GenerateToken(usuario);
                return new ResponseBase<string>(token);
            }
            catch (Exception erro)
            {
                return new ResponseBase<string>(erro.Message);
            }           
        }

        public async Task<ResponseBase<Usuario>> Regsitrar(UsuarioRequest usuarioRequest)
        {
            var senha = PasswordGenerator.Generate(25);
            var usuario = new Usuario()
            {
                Nome = usuarioRequest.Nome,
                Email = usuarioRequest.Email,
                Senha = PasswordHasher.Hash(senha)
            };
            // CHAMAR O REPOSITORY E SALVAR NA BASE VERIFICANDO PELO EMAIL SE O USUARIO JA EXISTE

            return new ResponseBase<Usuario>(usuario);
        }
    }
}
