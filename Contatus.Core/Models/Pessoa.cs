using System;
using System.Collections.Generic;
using System.Text;

namespace Organize.Core.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        //evitar nulos
        public string CPF { get; set; } = String.Empty;
        public DateTime? DataDeNascimento { get; set; }
        public bool EstaAtivo { get; set; }
        public string UserId { get; set; } = String.Empty;
    }
}
