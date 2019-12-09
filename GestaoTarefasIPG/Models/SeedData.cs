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
                new Funcao { NomeFuncao = "Secretaria" },
                new Funcao { NomeFuncao = "Tesouraria" },
                new Funcao { NomeFuncao = "Reprografia" },
                new Funcao { NomeFuncao = "Serviços Sociais" },
                new Funcao { NomeFuncao = "Cantina" },
                new Funcao { NomeFuncao = "Papelaria" }



                );
            db.SaveChanges();
        }
    }
}
