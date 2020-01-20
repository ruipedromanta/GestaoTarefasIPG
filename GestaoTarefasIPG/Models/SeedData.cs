using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models {
    public class SeedData {

        public const string ADMIN_ROLE = "admin";
        public const string MANAGEMENT_ROLE = "manager";

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
        public static void AdicionaEscolas(IPGDbContext db) {

            if (db.Escola.Any()) {
                return;
            }
            db.Escola.AddRange(
                new Escola { NomeEscola = "Escola Superior de Saúde", Telefone = "271205220"},
                new Escola { NomeEscola = "Escola Superior de Educação, Comunicação e Desporto", Telefone = "271220135" },
                new Escola { NomeEscola = "Escola Superior de Tecnologia e Gestão", Telefone = "271220164" },
                new Escola { NomeEscola = "Escola Superior de Turismo e Hotelaria", Telefone = "238320800" }
                );
            db.SaveChanges();
        }

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


        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager) {
            const string ADMIN_USERNAME = "admin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            const string MANAGEMENT_ROLE = "management@ipg.pt";
            const string MANAGEMENT_PASSWORD = "Manager123@";

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

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager) {
            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE)) {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }
        }
    }
    }
       
        
