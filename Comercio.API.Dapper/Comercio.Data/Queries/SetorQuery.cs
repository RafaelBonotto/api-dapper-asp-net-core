using Comercio.Domain.Entities;
using Dapper;
using System.Data;

namespace Comercio.Data.Queries
{
    public static class SetorQuery
    {
        public const string SELECT_SETOR = "SELECT * FROM comercioDB.tb_setor WHERE ativo = 1";

        public const string SELECT_SETOR_POR_ID = "SELECT * FROM comercioDB.tb_setor WHERE id = @Id";

        public const string SELECT_SETOR_POR_DESCRICAO = "SELECT * FROM comercioDB.tb_setor WHERE descricao = @Descricao";

        public const string DELETE_SETOR = "UPDATE comercioDB.tb_setor SET ativo = 0 WHERE id = @Id;";

        public static string RetornaQueryInsertSetor(Setor setor)
        {
            var query= "START TRANSACTION;" +
                        "INSERT INTO comercioDB.tb_setor(descricao, ativo, data_criacao, data_alteracao)" +
                        $"VALUES('{setor.Descricao}', 1, now(), now());" +
                        "SELECT LAST_INSERT_ID();" +
                        "COMMIT;";
            return query;
        }

        public static string RetornaQueryUpdateSetor(Setor setor)
        {
            var query = "START TRANSACTION;" +
                        $"UPDATE comercioDB.tb_setor SET " +
                        $"descricao = '{setor.Descricao}' , " +                       
                        "ativo = 1 , " +
                        "data_alteracao = now() " +
                        $"WHERE id = {setor.Id};" +
                        "COMMIT;";
            return query;
        }
    }
}
