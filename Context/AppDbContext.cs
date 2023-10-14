using gerenciamentodechamados.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentodechamados.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Chamado> chamados { get; set; }
    }
}
