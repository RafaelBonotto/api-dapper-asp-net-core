using System.Collections.Generic;

namespace Comercio.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Permissao> Permissoes { get; set; } = new();
    }
}
