using Comercio.Domain.Entities;
using Dapper;
using System.Data;

namespace Comercio.Data.Queries
{
    public static class SetorQuery
    {
        public const string SELECT_SETOR = "SELECT * FROM comercioDB.tb_setor WHERE ativo = 1";

        public const string SELECT_SETOR_POR_ID = "SELECT * FROM comercioDB.tb_setor WHERE id = @Id";

        public static string RetornaQueryInsertSetor(Setor setor)
        {
            return "INSERT INTO comercioDB.tb_setor(descricao, ativo, data_criacao, data_alteracao) " +
                   $"VALUES('{setor.Descricao}', 1, now(), now())";
        }
    }
}
