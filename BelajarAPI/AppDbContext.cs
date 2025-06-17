using BelajarAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BelajarAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produk> Produk { get; set; }
    }
}
