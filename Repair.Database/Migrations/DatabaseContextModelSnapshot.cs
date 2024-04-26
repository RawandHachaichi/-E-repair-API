﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repair.Database;

#nullable disable

namespace Repair.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repair.Database.Entities.Categorie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Repair.Database.Entities.CategorieComp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategorieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("CompetenceId");

                    b.ToTable("CategorieComp");
                });

            modelBuilder.Entity("Repair.Database.Entities.Cause", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Causes");
                });

            modelBuilder.Entity("Repair.Database.Entities.Competence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("Repair.Database.Entities.Delegation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GouvernoratId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GouvernoratId");

                    b.ToTable("Delegations");
                });

            modelBuilder.Entity("Repair.Database.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ContenuFichier")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DossierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExtensionDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomFichier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DossierId");

                    b.HasIndex("TypeDocumentId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("Repair.Database.Entities.Dossier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategorieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CauseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Debut")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DerniereModification")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DossierNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DossierStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LocalisationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MatiereId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ObjetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReparateurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeBatimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeDomageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeRendezVousId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Urgent")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("CauseId");

                    b.HasIndex("DossierStatusId");

                    b.HasIndex("LocalisationId");

                    b.HasIndex("MatiereId");

                    b.HasIndex("ObjetId");

                    b.HasIndex("TypeBatimentId");

                    b.HasIndex("TypeDomageId");

                    b.HasIndex("TypeRendezVousId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Dossiers");
                });

            modelBuilder.Entity("Repair.Database.Entities.DossierStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DossierStatus");
                });

            modelBuilder.Entity("Repair.Database.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TypeRendezVousId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeRendezVousId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Repair.Database.Entities.Gouvernorat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gouvernorats");
                });

            modelBuilder.Entity("Repair.Database.Entities.Localisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localisations");
                });

            modelBuilder.Entity("Repair.Database.Entities.Matiere", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Matiere");
                });

            modelBuilder.Entity("Repair.Database.Entities.Objet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Objets");
                });

            modelBuilder.Entity("Repair.Database.Entities.ReparateurCompetence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UtilisateurId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("ReparateurCompetences");
                });

            modelBuilder.Entity("Repair.Database.Entities.TypeBatiment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeBatiment");
                });

            modelBuilder.Entity("Repair.Database.Entities.TypeDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeDocument");
                });

            modelBuilder.Entity("Repair.Database.Entities.TypeDomage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeDomage");
                });

            modelBuilder.Entity("Repair.Database.Entities.TypeRendezVous", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeRendezVous");
                });

            modelBuilder.Entity("Repair.Database.Entities.Utilisateur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CreePar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DelegationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumMaison")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroTelephone1")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroTelephone2")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DelegationId");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Repair.Database.Entities.CategorieComp", b =>
                {
                    b.HasOne("Repair.Database.Entities.Categorie", "Categories")
                        .WithMany("CategorieComp")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Repair.Database.Entities.Competence", "Competences")
                        .WithMany("CategorieComp")
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Competences");
                });

            modelBuilder.Entity("Repair.Database.Entities.Delegation", b =>
                {
                    b.HasOne("Repair.Database.Entities.Gouvernorat", "Gouvernorat")
                        .WithMany("Delegations")
                        .HasForeignKey("GouvernoratId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gouvernorat");
                });

            modelBuilder.Entity("Repair.Database.Entities.Document", b =>
                {
                    b.HasOne("Repair.Database.Entities.Dossier", "Dossier")
                        .WithMany()
                        .HasForeignKey("DossierId");

                    b.HasOne("Repair.Database.Entities.TypeDocument", "TypeDocument")
                        .WithMany()
                        .HasForeignKey("TypeDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dossier");

                    b.Navigation("TypeDocument");
                });

            modelBuilder.Entity("Repair.Database.Entities.Dossier", b =>
                {
                    b.HasOne("Repair.Database.Entities.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.HasOne("Repair.Database.Entities.Cause", "Cause")
                        .WithMany()
                        .HasForeignKey("CauseId");

                    b.HasOne("Repair.Database.Entities.DossierStatus", "DossierStatus")
                        .WithMany()
                        .HasForeignKey("DossierStatusId");

                    b.HasOne("Repair.Database.Entities.Localisation", "Localisation")
                        .WithMany()
                        .HasForeignKey("LocalisationId");

                    b.HasOne("Repair.Database.Entities.Matiere", "Matiere")
                        .WithMany()
                        .HasForeignKey("MatiereId");

                    b.HasOne("Repair.Database.Entities.Objet", "Objet")
                        .WithMany()
                        .HasForeignKey("ObjetId");

                    b.HasOne("Repair.Database.Entities.TypeBatiment", "TypeBatiment")
                        .WithMany()
                        .HasForeignKey("TypeBatimentId");

                    b.HasOne("Repair.Database.Entities.TypeDomage", "TypeDomage")
                        .WithMany()
                        .HasForeignKey("TypeDomageId");

                    b.HasOne("Repair.Database.Entities.TypeRendezVous", "TypeRendezVous")
                        .WithMany()
                        .HasForeignKey("TypeRendezVousId");

                    b.HasOne("Repair.Database.Entities.Utilisateur", "Utilisateurs")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");

                    b.Navigation("Categorie");

                    b.Navigation("Cause");

                    b.Navigation("DossierStatus");

                    b.Navigation("Localisation");

                    b.Navigation("Matiere");

                    b.Navigation("Objet");

                    b.Navigation("TypeBatiment");

                    b.Navigation("TypeDomage");

                    b.Navigation("TypeRendezVous");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("Repair.Database.Entities.Event", b =>
                {
                    b.HasOne("Repair.Database.Entities.TypeRendezVous", "TypeRendezVous")
                        .WithMany()
                        .HasForeignKey("TypeRendezVousId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repair.Database.Entities.Utilisateur", "utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId");

                    b.Navigation("TypeRendezVous");

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("Repair.Database.Entities.ReparateurCompetence", b =>
                {
                    b.HasOne("Repair.Database.Entities.Competence", "Competences")
                        .WithMany("ReparateurCompetences")
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Repair.Database.Entities.Utilisateur", "Utilisateurs")
                        .WithMany("ReparateurCompetances")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competences");

                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("Repair.Database.Entities.Utilisateur", b =>
                {
                    b.HasOne("Repair.Database.Entities.Delegation", "Delegations")
                        .WithMany("Utilisateur")
                        .HasForeignKey("DelegationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Delegations");
                });

            modelBuilder.Entity("Repair.Database.Entities.Categorie", b =>
                {
                    b.Navigation("CategorieComp");
                });

            modelBuilder.Entity("Repair.Database.Entities.Competence", b =>
                {
                    b.Navigation("CategorieComp");

                    b.Navigation("ReparateurCompetences");
                });

            modelBuilder.Entity("Repair.Database.Entities.Delegation", b =>
                {
                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Repair.Database.Entities.Gouvernorat", b =>
                {
                    b.Navigation("Delegations");
                });

            modelBuilder.Entity("Repair.Database.Entities.Utilisateur", b =>
                {
                    b.Navigation("ReparateurCompetances");
                });
#pragma warning restore 612, 618
        }
    }
}
