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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var produto = await _produtoService.ObterProdutos();

            if (produto.Errors.Count > 0)
                return StatusCode(500, produto);

            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var produto = await _produtoService.ObterPorId(id);

            if (produto.Errors.Count > 0)
                return NotFound(produto);

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoRequest produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<Produto>(ModelState.GetErrors()));

            var novoProduto = await _produtoService.InserirProduto(produto);

            if (novoProduto.Errors.Count > 0)
                return StatusCode(500, novoProduto);

            return Created($"api/Produto/{novoProduto.Data.Id}", novoProduto);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] ProdutoRequest produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseBase<Produto>(ModelState.GetErrors()));

            var produtoAtualizado = await _produtoService.AtualizarProduto(id, produto);

            if (produtoAtualizado.Errors.Count > 0)
                return StatusCode(500, produtoAtualizado);

            return Ok(produtoAtualizado);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var produto = await _produtoService.ExcluirProduto(id);

            if (produto.Errors.Count > 0)
                return StatusCode(500, produto);

            return Ok(produto);
        }
    }
}
