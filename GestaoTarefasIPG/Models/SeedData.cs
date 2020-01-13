using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public static class SeedData {

        private const string ADMIN_ROLE = "admin";
        
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

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager) {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "PI1920";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null) {
                user = new IdentityUser {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_USERNAME
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN_ROLE)) {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }
           
        }

    }
}
