using Microsoft.EntityFrameworkCore;
using Repair.Database.Entities;

namespace Repair.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Gouvernorat> Gouvernorats { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<ReparateurCompetence> ReparateurCompetences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateur>()
             .HasOne(u => u.Delegation)
             .WithMany(d => d.Utilisateur)
             .HasForeignKey(u => u.DelegationId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delegation>()
               .HasOne(d => d.Gouvernorat)
               .WithMany(g => g.Delegations)
               .HasForeignKey(d => d.GouvernoratId)
               .OnDelete(DeleteBehavior.Restrict);

          

            modelBuilder.Entity<ReparateurCompetence>()
               .HasOne(R => R.Utilisateurs)
               .WithMany(U => U.ReparateurCompetances)
               .HasForeignKey(R => R.UtilisateurId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReparateurCompetence>()
             .HasOne(R => R.Competences)
             .WithMany(U => U.ReparateurCompetences)
             .HasForeignKey(R => R.CompetenceId)
             .OnDelete(DeleteBehavior.Restrict);


        }
    }
}