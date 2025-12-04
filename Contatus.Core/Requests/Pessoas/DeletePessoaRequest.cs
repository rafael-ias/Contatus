using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Requests.Pessoas
{
    public class DeletePessoaRequest : Request
    {
        public int Id { get; set; }
    }
}
