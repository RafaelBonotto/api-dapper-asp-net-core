using System.ComponentModel.DataAnnotations;

namespace Comercio.Services.Request
{
    public class SetorRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
    }
}
