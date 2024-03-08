using Microsoft.EntityFrameworkCore;
using Repair.Database.Entities;

namespace Repair.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Gouvernorat> Gouvernorats { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Competance> Competances { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<ReparateurCompetance> ReparateurCompetances { get; set; }


    }
}