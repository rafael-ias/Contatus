using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Requests.Telefones
{
    public class GetTelefoneByIdRequest : Request
    {
        public int Id { get; set; }
    }
}
