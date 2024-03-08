using E_repair.Models;
using Microsoft.EntityFrameworkCore;

namespace Repair.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Gouvernorat> Gouvernorat { get; set; }
    }
}