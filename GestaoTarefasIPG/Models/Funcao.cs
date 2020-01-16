using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Funcao {


        public int FuncaoId { get; set; }


        [Required(ErrorMessage = "Introduza o nome da função por favor")]
        [StringLength(128)]
        [MinLength(3, ErrorMessage = "O nome tem de ter menos de 3 carateres")]
        public string NomeFuncao { get; set; }

    }
}