using Comercio.Domain.Base;
using Comercio.Domain.Entities;

namespace Comercio.Services.Response
{
    public class SetorResponse : StatusResult
    {
        public Setor Setor{ get; set; }
    }
}
