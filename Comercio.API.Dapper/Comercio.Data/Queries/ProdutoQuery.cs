namespace Comercio.Data.Queries
{
    public class ProdutoQuery
    {
        public const string  SELECT_PRODUTOS = "SELECT * FROM tb_produto WHERE ativo = 1";

        public const string  SELECT_PRODUTO_POR_ID = "SELECT * FROM tb_produto WHERE id = @Id";
    }
}
