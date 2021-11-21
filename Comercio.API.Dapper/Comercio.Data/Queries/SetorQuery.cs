namespace Comercio.Data.Queries
{
    public class SetorQuery
    {
        public const string SELECT_SETOR = "SELECT * FROM tb_setor WHERE ativo = 1";

        public const string SELECT_SETOR_POR_ID = "SELECT * FROM tb_setor WHERE id = @Id";
    }
}
