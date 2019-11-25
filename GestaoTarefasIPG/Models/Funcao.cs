using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Funcao {

        public int FuncaoId { get; set; }

        
        [Required]
        [StringLength(128)]
        public string NomeFuncao { get; set; }

    }
}
