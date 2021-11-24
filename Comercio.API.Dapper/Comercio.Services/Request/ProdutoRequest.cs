using System.ComponentModel.DataAnnotations;

namespace Comercio.Services.Request
{
    public class ProdutoRequest
    {

        [Required(ErrorMessage = "Código obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço de custo obrigatório")]
        public decimal Preco_custo { get; set; }

        [Required(ErrorMessage = "Preço de venda obrigatório")]
        public decimal Preco_venda { get; set; }       
        public long Setor_id { get; set; }

    }
}
