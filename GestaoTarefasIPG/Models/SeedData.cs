using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {

        private static void AdicionaFuncoes(IPGDbContext db) {
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



        private static void AdicionaDepartamentos(IPGDbContext db) {
            if (db.Departamento.Any()) {
                return;
            }
            db.Departamento.AddRange(
                new Departamento { NomeDepartamento = "Secretaria" },
                new Departamento { NomeDepartamento = "Tesouraria" },
                new Departamento { NomeDepartamento = "Reprografia" },
                new Departamento { NomeDepartamento = "Serviços Sociais" },
                new Departamento { NomeDepartamento = "Cantina" },
                new Departamento { NomeDepartamento = "Papelaria" }
                );

        }
    }
}
