using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comercio.Data.Repository
{
    public class SetorRepository : ISetorRepository
    {
        private readonly IMySqlConnectionManager _connection;

        public SetorRepository(IMySqlConnectionManager connection)
        {
            _connection = connection;
        }

        public async Task<List<Setor>> ObterSetor()
        {
            List<Setor> setorBanco;

            using (var connection =await _connection.GetConnectionAsync())
            {
                setorBanco = connection.Query<Setor>(SetorQuery.SELECT_SETOR).ToList();
            }

            return setorBanco;
        }

        public async Task<Setor> ObterSetorPorId(int id)
        {
            Setor setor;

            using (var connection = await _connection.GetConnectionAsync())
            {
                setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = id });
            }

            return setor;
        }
    }
}