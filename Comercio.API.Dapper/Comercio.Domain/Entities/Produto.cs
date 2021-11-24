using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Comercio.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            Tb_FornecedorProduto = new List<FornecedorProduto>();
            Tb_Setor = new Setor();
        }

        public long Id { get; set; }

        [Required(ErrorMessage ="Código obrigatório")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="Preço de custo obrigatório")]
        public decimal Preco_custo { get; set; }

        [Required(ErrorMessage ="Preço de venda obrigatório")]
        public decimal Preco_venda { get; set; }
        public DateTime Data_fabricacao { get; set; }
        public DateTime Data_validade { get; set; }
        public sbyte Ativo { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }
        public long Setor_id { get; set; }

        public virtual ICollection<FornecedorProduto> Tb_FornecedorProduto { get; set; }
        public virtual Setor Tb_Setor { get; set; }

    }
}
