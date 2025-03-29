using Microsoft.EntityFrameworkCore;
using SeguroAPI.Models;

namespace SeguroAPI.Data
{
    public class SeguroDbContext : DbContext
    {
        public SeguroDbContext(DbContextOptions<SeguroDbContext> options) : base(options) { }

        public DbSet<Asegurado> Asegurados { get; set; }
    }
}
