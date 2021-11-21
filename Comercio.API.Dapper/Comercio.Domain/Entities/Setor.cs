using System;

namespace Comercio.Domain.Entities
{
    public class Setor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public sbyte Ativo { get; set; } 
        public DateTime Data_criacao { get; set; }
        public DateTime Data_alteracao { get; set; }
    }
}
