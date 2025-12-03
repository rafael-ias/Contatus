using Contatus.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatus.Core.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; } = Tipo.Celular;
        public string Numero { get; set; } = String.Empty;
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; } = null!;
        public string UserId { get; set; } = String.Empty;
    }
}
