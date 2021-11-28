using Comercio.Domain.Entities;

namespace Comercio.Data.Queries
{
    public static class ProdutoQuery
    {
        public const string  SELECT_PRODUTOS = "SELECT * FROM comercioDB.tb_produto WHERE ativo = 1";

        public const string  SELECT_PRODUTO_POR_ID = "SELECT * FROM comercioDB.tb_produto WHERE id = @Id";

        public const string  SELECT_PRODUTO_POR_CODIGO = "SELECT * FROM comercioDB.tb_produto WHERE codigo = @Codigo";

        public const string  DELETE_PRODUTO = "UPDATE comercioDB.tb_produto SET ativo = 0 WHERE id = @Id;";

        public static string RetornaQueryInsertProduto(Produto produto)
        {
            var query = "START TRANSACTION;" +
                        "INSERT INTO comercioDB.tb_produto " +
                        "(codigo, descricao, preco_custo, preco_venda, data_fabricacao, data_validade, ativo, data_criacao, data_alteracao, setor_id)" +
                        $"VALUES ('{produto.Codigo}', '{produto.Descricao}', {produto.Preco_custo}, {produto.Preco_venda}, now(), now(), 1, now(), now(), {produto.Setor_id});" +
                        "SELECT LAST_INSERT_ID();" +
                        "COMMIT;";
            return query;
        }

        public static string RetornaQueryUpdateProduto(Produto produto)
        {
            var query = $"UPDATE comercioDB.tb_produto SET " +
                        $"codigo = '{ produto.Codigo}' , " +
                        $"descricao = '{produto.Descricao}' , " +
                        $"preco_custo = {produto.Preco_custo} , " +
                        $"preco_venda = {produto.Preco_venda} , " +
                        $"setor_id = {produto.Setor_id} , " +
                        "ativo = 1 , " +
                        "data_alteracao = now() " +
                        $"WHERE id = {produto.Id};";
            return query;
        }
    }
}
