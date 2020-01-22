using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //[ForeignKey("Escola")]
        //public int EscolaId { get; set; }
        //public Escola Escola { get; set; }

    }
}

        //public ICollection<Escola> Escolas { get; set; }
   

