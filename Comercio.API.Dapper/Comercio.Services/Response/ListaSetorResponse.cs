using Comercio.Domain.Base;
using Comercio.Domain.Entities;
using System.Collections.Generic;

namespace Comercio.Services.Response
{
    public class ListaSetorResponse : StatusResult
    {
        public ListaSetorResponse()
        {
            Setores = new List<Setor>();
        }
        public List<Setor> Setores { get; set; }
    }
}
