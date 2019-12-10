using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public static class SeedData {
        
        
        public static void AdicionaEscolas (IPGDbContext db) {

            if (db.Escola.Any()) {
                return;
            }
               
            db.Escola.AddRange(
                new Escola { NomeEscola = "Escola Superior de Saúde", Telefone = "271205220" },
                new Escola { NomeEscola = "Escola Superior de Educação, Comunicação e Desporto", Telefone = "271220135" },
                new Escola { NomeEscola = "Escola Superior de Tecnologia e Gestão", Telefone = "271220164" },
                new Escola { NomeEscola = "Escola Superior de Turismo e Hotelaria", Telefone = "238320800" }
                );

            db.SaveChanges();
        }
            
    }
}
