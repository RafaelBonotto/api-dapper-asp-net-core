using System;
using System.Collections.Generic;

namespace Comercio.Domain.Entities
{
    public class Produto
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Setor { get; set; }
        public decimal Preco_custo { get; set; }
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
