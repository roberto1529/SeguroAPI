using Microsoft.EntityFrameworkCore;
using SeguroAPI.Models;

namespace SeguroAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Asegurado> Asegurados { get; set; }
    }
}
