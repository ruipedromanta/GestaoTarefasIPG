using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasIPG.Models
{
    public class DepartamentoDbContext : DbContext
    {
        public DepartamentoDbContext (DbContextOptions<DepartamentoDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Departamento> Departamento { get; set; }
    }
}
