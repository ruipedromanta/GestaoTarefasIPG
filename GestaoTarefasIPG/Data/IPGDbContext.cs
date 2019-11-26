using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasIPG.Models
{
    public class IPGDbContext : DbContext
    {
        public IPGDbContext (DbContextOptions<IPGDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Departamento> Departamento { get; set; }
    }
}
