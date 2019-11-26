using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public static class SeedData {
        public static void Populate(IPGDbContext db) {
            PopulateEscolas(db);
        }

        private static void PopulateEscolas (IPGDbContext db) {

            if (db.Escola.Any()) return;

            db.Escola.AddRange(
                new Escola { NomeEscola = "Escola Superior de Saúde", Telefone = "271205220"}
                );

            db.SaveChanges();
        }
            
    }
}
