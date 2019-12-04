using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Escola {
        public int EscolaId { get; set; }
        [Required]
        [StringLength(128)]
        public string NomeEscola { get; set; }
        [Required]
        [StringLength(9)]
        public string Telefone { get; set; }
    }
}
