using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Departamento {

        [Required]
        public int DepartamentoId { get; set; }
        [Required]
        [StringLength(120)]
        public string NomeDepartamento { get; set; }
        
    }
}
