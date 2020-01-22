using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {

        public static void AdicionaFuncoes(IPGDbContext db) {
            if (db.Funcao.Any()) {
                return;
            }


            db.Funcao.AddRange(
                new Funcao { NomeFuncao = "Presidente" },
                new Funcao { NomeFuncao = "Vice Presidente" },
                new Funcao { NomeFuncao = "Diretor" },
                new Funcao { NomeFuncao = "Auxiliar" },
                new Funcao { NomeFuncao = "Professor" }
                



                );
            db.SaveChanges();
        }
    }
}
