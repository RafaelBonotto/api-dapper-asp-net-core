using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMySqlConnectionManager _connection;

        public UsuarioRepository(IMySqlConnectionManager connection)
        {
            _connection = connection;
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                Usuario usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(UsuarioQuery.SELECT_USUARIO, new { Email = email });
                if (usuario == null)
                    throw new Exception("Usuário ou senha inválidos");

                return usuario;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Task<Usuario> Registrar()
        {
            throw new System.NotImplementedException();
        }
    }
}
