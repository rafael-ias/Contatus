using Contatus.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatus.Core.Requests.Pessoas
{
    public class UpdatePessoaRequest : CreatePessoaRequest
    {
        public int Id { get; set; }

        //Data Annotations
        [Required(ErrorMessage = "Nome Inválido")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no máximo 255 caracteres")]
        public string Nome { get; set; } = String.Empty;

        [Required(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; } = String.Empty;

        public bool EstaAtivo { get; set; }

        public DateTime? DataDeNascimento { get; set; }


        [Required(ErrorMessage = "Telefone inválido")]
        public ICollection<Telefone> Telefones { get; } = new List<Telefone>();
    }
}
