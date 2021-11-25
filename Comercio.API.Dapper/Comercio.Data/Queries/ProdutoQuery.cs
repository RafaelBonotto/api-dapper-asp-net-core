using Comercio.Domain.Entities;

namespace Comercio.Data.Queries
{
    public static class ProdutoQuery
    {
        public const string  SELECT_PRODUTOS = "SELECT * FROM comercioDB.tb_produto WHERE ativo = 1";

        public const string  SELECT_PRODUTO_POR_ID = "SELECT * FROM comercioDB.tb_produto WHERE id = @Id";

        public static string RetornaQueryInsertProduto(Produto produto)
        {
            return  "INSERT INTO comercioDB.tb_produto " +
                    "(codigo, descricao, preco_custo, preco_venda, data_fabricacao, data_validade, ativo, data_criacao, data_alteracao, setor_id)" +
                    $"VALUES ('{produto.Codigo}', '{produto.Descricao}', {produto.Preco_custo}, {produto.Preco_venda}, now(), now(), 1, now(), now(), {produto.Setor_id})";
        }
    }
}
