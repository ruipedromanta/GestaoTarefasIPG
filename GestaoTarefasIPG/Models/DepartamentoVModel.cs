using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GestaoTarefasIPG.Models {
    public class DepartamentoVModel {
        public IEnumerable<Departamento> Departamento { get; set; }

        public int PagAtual { get; set; }

        public int TotPaginas { get; set; }

        public int PriPagina { get; set; }

        public int UltPagina { get; set; }

        public string StringProcura { get; set;  }

        public string Sort { get; set; }
    }
}