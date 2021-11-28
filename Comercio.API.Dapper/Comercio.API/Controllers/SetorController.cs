using Comercio.Services.Interfaces;
using Comercio.Services.Request;
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
        public async Task<IActionResult> ObterSetorPorId(long id)
        {
            return Ok(await _setorService.ObterSetorPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> InserirSetor(SetorRequest setor)
        {
            return Ok(await _setorService.InserirSetor(setor));
        }

        [HttpPost("atualizar/{setorId}")]
        public async Task<IActionResult> AtualizarSetor(long setorId, SetorRequest setor)
        {
            return Ok(await _setorService.AtualizarSetor(setorId, setor));
        }

        [HttpPost("excluir/{setorId}")]
        public async Task<IActionResult> ExcluirSetor(long setorId)
        {
            return Ok(await _setorService.ExcluirSetor(setorId));
        }
    }
}
