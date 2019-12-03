using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {

        public static void Populate(DepartamentoDbContext db) {
            if (db.Departamento.Any()) {
                return;
            }

            db.Funcao.AddRange(
                new Funcao { NomeFuncao = "" },
                new Funcao { NomeFuncao = "" },
                new Funcao { NomeFuncao = "" },
                new Funcao { NomeFuncao = " " },
                new Funcao { NomeFuncao = "" },
                new Funcao { NomeFuncao = "" }
                );

            db.Departamento.AddRange(
                new Departamento { NomeDepartamento = "Secretaria", NumeroDepartamento = "15874698"},
                new Departamento { NomeDepartamento = "Tesouraria", NumeroDepartamento = "15324896"},
                new Departamento { NomeDepartamento = "Reprografia", NumeroDepartamento = "15247896"},
                new Departamento { NomeDepartamento = "Serviços Sociais", NumeroDepartamento = "15247896"},
                new Departamento { NomeDepartamento = "Cantina", NumeroDepartamento = "15478563"},
                new Departamento { NomeDepartamento = "Papelaria", NumeroDepartamento = "15478965"}
                


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
