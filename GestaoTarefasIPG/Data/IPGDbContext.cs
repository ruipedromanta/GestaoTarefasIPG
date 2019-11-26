using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasIPG.Models
{
    public class IPGDbContext : DbContext
    {
        public IPGDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
    }
}
