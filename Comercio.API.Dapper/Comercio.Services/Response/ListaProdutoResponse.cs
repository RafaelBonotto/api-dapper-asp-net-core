using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using System.Collections.Generic;

namespace Comercio.Services.Response
{
    public class ListaProdutoResponse : StatusResult
    {
        public ListaProdutoResponse()
        {
            Produtos = new List<Produto>();
        }
        public List<Produto> Produtos { get; set; }
    }
}
