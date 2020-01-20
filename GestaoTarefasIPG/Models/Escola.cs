using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Escola {
        public int EscolaId { get; set; }
        [Required(ErrorMessage = "Introduza o nome da escola por favor")]
        [MinLength(10, ErrorMessage = "O nome tem de ter menos de 10 carateres")]
        [StringLength(128)]
        public string NomeEscola { get; set; }
        [Required]
        [StringLength(9)]
        [RegularExpression(@"2\d{8}", ErrorMessage = "Introduza um número de telefone válido")]
        public string Telefone { get; set; }
    }
}