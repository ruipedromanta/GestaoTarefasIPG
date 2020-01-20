using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Models
{
    public class IPGDbContext : DbContext
    {
        public IPGDbContext (DbContextOptions<IPGDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Departamento> Departamento { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Escola> Escola { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Funcao> Funcao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //Relação 1 -> N
           /* modelBuilder.Entity<Escola>()
                .HasOne(p => p.Departamento)
                .WithMany(p => p.Escolas)
                .HasForeignKey(p => p.DepartamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            */
        }
    }
}
