using Comercio.Domain.Base;
using Comercio.Domain.Entities;

namespace Comercio.Services.Response
{
    public class ProdutoResponse : StatusResult
    {      
        public Produto Produto { get; set; }
    }

}
