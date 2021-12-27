using System.ComponentModel.DataAnnotations;

namespace Comercio.Services.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage =("Informe o E-mail"))]
        [EmailAddress(ErrorMessage =("E-mail inválido"))]
        public string Email { get; set; }

        [Required(ErrorMessage =("Informe a senha"))]
        public string Senha { get; set; }
    }
}
