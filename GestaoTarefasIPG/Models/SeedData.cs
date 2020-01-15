using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {


        private const string ADMIN_ROLE = "admin";


        public static void AdicionaDepartamentos(IPGDbContext db) {
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
            db.SaveChanges();
        }

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager) {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null) {
                user = new IdentityUser {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_USERNAME
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }
        }
        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager) {
            //const string CAN_ADD_MENUS = "can_add_menus";

            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE)) {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }
        }
    }
}


        
