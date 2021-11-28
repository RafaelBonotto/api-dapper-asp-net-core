using Comercio.Data.ConnectionManager;
using Comercio.Data.Queries;
using Comercio.Domain.Entities;
using Comercio.Domain.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    setorBanco = connection.Query<Setor>(SetorQuery.SELECT_SETOR).ToList();
                }

                return setorBanco;
            }
            catch (System.Exception)
            {
                throw;
            }
           
        }

        public async Task<Setor> InserirSetor(Setor setor)
        {
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    var checkDescricao = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_DESCRICAO, new { Descricao = setor.Descricao });
                    if (checkDescricao != null)
                        throw new Exception("Não foi possível inserir o setor com essa descrição");

                    var setorId = await connection.ExecuteScalarAsync<long>(SetorQuery.RetornaQueryInsertSetor(setor));
                    return await this.ObterSetorPorId(setorId);
                }                
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        public async Task<Setor> AtualizarSetor(Setor setor)
        {
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    var checkDescricao = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_DESCRICAO, new { Descricao = setor.Descricao });
                    if (checkDescricao != null)
                        throw new Exception("Não foi possível atualizar o setor com essa descrição");

                    var setorId = await connection.ExecuteScalarAsync<long>(SetorQuery.RetornaQueryUpdateSetor(setor));
                    return await this.ObterSetorPorId(setorId);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Setor> ObterSetorPorId(long id)
        {
            Setor setor;
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = id });
                }

                return setor;
            }
            catch (System.Exception)
            {
                throw;
            }            
        }

        public async Task<bool> ExcluirSetor(long setorId)
        {
            try
            {
                using (var connection = await _connection.GetConnectionAsync())
                {
                    return await connection.QueryAsync<Setor>(SetorQuery.DELETE_SETOR, new { Id = setorId }) != null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}