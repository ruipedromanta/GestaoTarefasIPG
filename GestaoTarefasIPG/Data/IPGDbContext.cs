using GestaoTarefasIPG.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Data {
    public class IPGDbContext : DbContext {
        public IPGDbContext (DbContextOptions<IPGDbContext> options) : base(options) {

        }

        public DbSet<GestaoTarefasIPG.Models.Escola> Escola { get; set; }
    }
}
