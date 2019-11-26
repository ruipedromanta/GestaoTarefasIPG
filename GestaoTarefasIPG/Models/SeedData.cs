using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {

        public static void Populate(IPGDbContext  db) {
            PopulateDepartamento(db);
        }

        private static void PopulateDepartamento(IPGDbContext db) {

            if (db.Departamento.Any()) return;

            db.Departamento.AddRange(
                new Departamento { NomeDepartamento = "Secretaria", NumeroDepartamento = "352643268"},
                 new Departamento { NomeDepartamento = "Secretaria", NumeroDepartamento = "352643268" }














                );
            db.SaveChanges();
        }
    }
}
