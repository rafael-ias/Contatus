using Organize.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organize.Core.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; } = Tipo.Celular;
        public string UserId { get; set; } = String.Empty;
    }
}
