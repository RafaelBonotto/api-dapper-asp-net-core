using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Domain.Extensions;
using Comercio.Domain.Services;
using Comercio.Services.Interfaces;
using Comercio.Services.Request;
using Comercio.Services.Services;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;
using System.Threading.Tasks;

namespace Comercio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioRequest usuarioRequest, [FromServices] IUsuarioService usuarioService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<string>(ModelState.GetErrors()));            

            return Ok(await usuarioService.Regsitrar(usuarioRequest));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest, [FromServices] IUsuarioService usuarioService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<string>(ModelState.GetErrors()));

            return Ok(await usuarioService.Login(loginRequest));
        }
    }
}
