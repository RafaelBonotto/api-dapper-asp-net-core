using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly IMySqlConnectionManager _connection;

        public PermissaoRepository(IMySqlConnectionManager connection)
        {
            _connection = connection;
        }
        public async Task<List<Permissao>> ObterPermissaoUsuario(long idUsuario)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                List<Permissao> permissoesUsuario = connection.Query<Permissao>
                                    (PermissaoQuery.SELECT_PERMISSAO_USUARIO, new { IdUsuario = idUsuario }).ToList();
                return permissoesUsuario;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
