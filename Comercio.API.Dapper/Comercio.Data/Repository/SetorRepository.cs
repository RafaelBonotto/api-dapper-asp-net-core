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
    public class SetorRepository : ISetorRepository
    {
        private readonly IMySqlConnectionManager _connection;

        public SetorRepository(IMySqlConnectionManager connection)
        {
            _connection = connection;
        }

        public async Task<List<Setor>> ObterSetor()
        {            
            try
            {
                List<Setor> setorBanco;
                using var connection = await _connection.GetConnectionAsync();
                setorBanco = connection.Query<Setor>(SetorQuery.SELECT_SETOR).ToList();
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
                using var connection = await _connection.GetConnectionAsync();
                var checkDescricao = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_DESCRICAO, new { Descricao = setor.Descricao });
                if (checkDescricao != null)
                    throw new Exception("Não foi possível inserir o setor com essa descrição");
                var setorId = await connection.ExecuteScalarAsync<long>(SetorQuery.RetornaQueryInsertSetor(setor));

                return await this.ObterSetorPorId(setorId);
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
                using var connection = await _connection.GetConnectionAsync();
                await connection.QueryAsync(SetorQuery.RetornaQueryUpdateSetor(setor));
                return await this.ObterSetorPorId(setor.Id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Setor> ObterSetorPorId(long id)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                var setor = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = id });
                if (setor == null)
                    throw new Exception("Setor não encontrado no sistema");
                return setor;
            }
            catch (System.Exception)
            {
                throw;
            }            
        }

        public async Task<bool> ExcluirSetor(long id)
        {
            try
            {
                using var connection = await _connection.GetConnectionAsync();
                var setorExiste = await connection.QueryFirstOrDefaultAsync<Setor>(SetorQuery.SELECT_SETOR_POR_ID, new { Id = id }) != null;
                if (!setorExiste)
                    throw new Exception("Setor não encontrado no sistema");
                return await connection.QueryAsync<Setor>(SetorQuery.DELETE_SETOR, new { Id = id }) != null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}