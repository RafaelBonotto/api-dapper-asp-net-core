using Comercio.Domain.Entities;
using Comercio.Services.Interfaces;
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

        [HttpGet("listar")]
        public async Task<IActionResult> ListarProdutos()
        {
            return Ok(await _produtoService.ObterProdutos());
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            return Ok(await _produtoService.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> InserirProduto(Produto produto)
        {
            return Ok(_produtoService.InserirProduto(produto));
        }
    }
}
