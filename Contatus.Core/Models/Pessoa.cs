using System;
using System.Collections.Generic;
using System.Text;

namespace Contatus.Core.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        //evitar nulos
        public string Nome { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public DateTime? DataDeNascimento { get; set; }
        public bool EstaAtivo { get; set; }
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
        public string UserId { get; set; } = String.Empty;
    }
}
