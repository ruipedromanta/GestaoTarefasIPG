using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Departamento {

        [Required]
        public int DepartamentoId { get; set; }
        
        [StringLength(20)]
        [Required(ErrorMessage = "Introduza o nome do departamento por favor")]
        [MinLength(3, ErrorMessage = "O nome tem de ter menos de 3 carateres")]
        public string NomeDepartamento { get; set; }
        
    }
}
