using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public interface IGestaoTarefasIPGRepository {
        public IEnumerable<Escola> Escolas { get; }
    }
}
