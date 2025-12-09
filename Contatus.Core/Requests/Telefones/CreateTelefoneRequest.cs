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
    public class CreateTelefoneRequest : Request
    {
        //Data Annotations
        [Required(ErrorMessage = "Numero Invalido")]
        [MaxLength(20, ErrorMessage = "Numero deve ter no maximo 20 caracteres")]
        public string Numero { get; set; } = String.Empty;

        public Tipo Tipo { get; set; } = Tipo.Celular;

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; } = null!;
    }
}
