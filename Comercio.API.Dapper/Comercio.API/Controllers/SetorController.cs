using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using Comercio.Domain.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var setor = await _setorService.ObterSetor();

            if (setor.Errors.Count > 0)
                return StatusCode(500, setor);

            return Ok(setor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var setor = await _setorService.ObterSetorPorId(id);

            if (setor.Errors.Count > 0)
                return NotFound(setor);

            return Ok(setor);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SetorRequest setor)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<Setor>(ModelState.GetErrors()));

            var novoSetor = await _setorService.InserirSetor(setor);

            if (novoSetor.Errors.Count > 0)
                return StatusCode(500, novoSetor);

            return Created($"api/Setor/{novoSetor.Data.Id}", novoSetor);
        }

        [HttpPost("atualizar/{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] SetorRequest setor)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<Setor>(ModelState.GetErrors()));

            var setorAtualizado = await _setorService.AtualizarSetor(id, setor);

            if (setorAtualizado.Errors.Count > 0)
                return StatusCode(500, setorAtualizado);

            return Ok(setorAtualizado);
        }

        [HttpPost("excluir/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var setor = await _setorService.ExcluirSetor(id);

            if (setor.Errors.Count > 0)
                return StatusCode(500, setor);

            return Ok(setor);
        }
    }
}
