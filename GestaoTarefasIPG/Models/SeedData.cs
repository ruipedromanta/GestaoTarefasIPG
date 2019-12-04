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
                new Funcao { NomeFuncao = "Assistente Operacional" },
                new Funcao { NomeFuncao = "Professor" },
                new Funcao { NomeFuncao = "Assistente Técnica" },
                new Funcao { NomeFuncao = "Bibliotecária" },
                new Funcao { NomeFuncao = "Diretor" },
                new Funcao { NomeFuncao = "Presidente" },
                new Funcao { NomeFuncao = "Tesoureiro" },
                new Funcao { NomeFuncao = "Vice-Presidente" },
                new Funcao { NomeFuncao = "Secretária" }
                

                );
            db.SaveChanges();
        }
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
                new Escola {NomeEscola = "Escola Superior de Saúde", Telefone = "271205220" },
                new Escola { NomeEscola = "Escola Superior de Educação, Comunicação e Desporto", Telefone = "271220135" },
                new Escola {NomeEscola = "Escola Superior de Tecnologia e Gestão", Telefone = "271220164" },
                new Escola {NomeEscola = "Escola Superior de Turismo e Hotelaria", Telefone = "238320800" }
                
                );
            db.SaveChanges();
        }
    }
}
