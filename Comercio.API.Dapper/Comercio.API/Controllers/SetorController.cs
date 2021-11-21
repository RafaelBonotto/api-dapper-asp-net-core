using Comercio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Comercio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _setorService;

        public SetorController(ISetorService setorService)
        {
            _setorService = setorService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObterSetor()
        {
            return Ok(await _setorService.ObterSetor());
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObterSetorPorId(int id)
        {
            return Ok(await _setorService.ObterSetorPorId(id));
        }
    }
}
