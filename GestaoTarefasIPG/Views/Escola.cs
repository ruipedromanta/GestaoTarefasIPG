using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Views {
    public class Escola {
        [Required]
        public int EscolaId { get; set; }
        [Required]
        public string NomeEscola { get; set; }
        [Required]
        public string MoradaEscola { get; set; }
        [Required]
        [StringLength=9]
        public string Telefone { get; set; }
    }
}
