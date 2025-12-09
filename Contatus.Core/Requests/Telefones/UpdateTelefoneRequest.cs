using Contatus.Core.Enums;
using Contatus.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Requests.Telefones
{
    public class UpdateTelefoneRequest : CreateTelefoneRequest
    {
        public int Id { get; set; }
    }
}
