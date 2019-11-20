using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class Funções {
        
        [Required]
        public int FuncaoId { get; set; }

       [Required]
        public string NomeFuncao { get; set; }

        [Required]
        public string Attribute3 { get; set; }

        [Required]
        public string FuncionarioFuncionarioId { get; set; }



    }
}
