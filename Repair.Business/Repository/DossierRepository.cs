﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Repository
{
    public class DossierRepository : IDossierRepository
    {
        private readonly DatabaseContext _databaseContext;

        public DossierRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private string GenerateDossierNumber()
        {
            int count = _databaseContext.Dossiers.Count() + 1;
            var dossierNumber = "DOS2014T" + count;
            return dossierNumber;
        }

        public Dossier AddDossier(ReclamationModel Dossier)
        {
            try
            {
                var statusId = _databaseContext.DossierStatus.FirstOrDefault(x => x.code == "AP").Id;

                var newDossier = new Dossier()
                {
                    Id = Guid.NewGuid(),
                    DossierNumber = GenerateDossierNumber(),
                    CategorieId = Dossier.Categorie.Id,
                    CauseId = Dossier.Damage.Cause.Id,
                    DossierStatusId = statusId,
                    Urgent = Dossier.Damage.IsEmergency,
                    LocalisationId = Dossier.Damage.Localisation.Id,
                    MatiereId = Dossier.Damage.Matiere.Id,
                    ObjetId = Dossier.Damage.Objets.Id,
                    TypeBatimentId = Dossier.Damage.BuildingType.Id,
                    TypeDomageId = Dossier.Damage.TypeDomage.Id,
                    Description = Dossier.Damage.Description,
                    TypeRendezVousId = Dossier.ChoixReparateur.RendezVous.TypeRendezVous.Id,
                    DateCreation = DateTime.Now,
                    CreePar = Dossier.Email,
                    UtilisateurId = Dossier.UtilisateurId,
                    ReparateurId = Dossier.ChoixReparateur.Reparateur.Id,
                    Debut = Dossier.ChoixReparateur.RendezVous.Start,
                    Fin = Dossier.ChoixReparateur.RendezVous.End,
                };

                _databaseContext.Dossiers.Add(newDossier);
                _databaseContext.SaveChanges();

                return newDossier;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions et retourner null en cas d'erreur
                return null;
            }
        }

        public List<DossierModel> GetDossierByUserId(Guid? Utilisateurid , string role )

        {
            if(role == "client") {
                var  res = _databaseContext.Dossiers
                .Include(x => x.DossierStatus)
                 .Include(x => x.Categorie)
                .Where(x => x.UtilisateurId == Utilisateurid)
                .Select(x => new DossierModel()
                {
                    Id = x.Id,
                    Urgent = (bool)x.Urgent ? "Oui" : "Non",
                    DossierStatus = new ItemModel { Id = (Guid)x.DossierStatusId, Nom = x.DossierStatus.Nom },
                   Categorie = new ItemModel { Id = (Guid)x.CategorieId, Nom = x.Categorie.Nom },
                    DossierNumber = x.DossierNumber,
                    CreePar = x.CreePar,
                    DateCreation = x.DateCreation
                })
                .ToList();

            return res;
            }
            else
            {
                var res = _databaseContext.Dossiers
               .Include(x => x.DossierStatus)
                 .Include(x => x.Categorie)
               .Where(x => x.ReparateurId == Utilisateurid)
               .Select(x => new DossierModel()
               {
                   Id = x.Id,
                   Urgent = (bool)x.Urgent ? "Oui" : "Non",
                   DossierStatus = new ItemModel { Id = (Guid)x.DossierStatusId, Nom = x.DossierStatus.Nom },
                   Categorie = new ItemModel { Id = (Guid)x.CategorieId, Nom = x.Categorie.Nom },
                   DossierNumber = x.DossierNumber,
                   CreePar = x.CreePar,
                   DateCreation = x.DateCreation
               })
               .ToList();

                return res;
            }

        } 

        public DossierModel GetDossierById(Guid? id)
       {
            return _databaseContext.Dossiers
                .Include(x => x.DossierStatus)
                .Include(x => x.Matiere)
                .Include(x => x.Objet)
                .Include(x => x.Localisation)
                .Include(x => x.TypeBatiment)
                .Include(x => x.TypeDomage)
                .Include(x => x.TypeRendezVous)
                .Include(x => x.Cause)
                .Include(x => x.Utilisateurs)
                    .ThenInclude(u => u.Delegations)
                        .ThenInclude(d => d.Gouvernorat)
                .Include(x => x.Categorie)
                .Where(x => x.Id == id)
                .Select(x => new DossierModel()
                {
                    Id = x.Id,
                    Urgent = (bool)x.Urgent ? "Oui" : "Non",
                    DossierNumber = x.DossierNumber,
                    CreePar = x.Utilisateurs.Email,
                    Description = x.Description,
                    DateCreation = x.DateCreation,
                    Cause = new ItemModel { Id = (Guid)x.Id, Nom = x.Cause.Nom },
                    DossierStatus = new ItemModel { Id = (Guid)x.DossierStatusId, Nom = x.DossierStatus.Nom,Code=x.DossierStatus.code },
                    Matiere = new ItemModel { Id = (Guid)x.MatiereId, Nom = x.Matiere.Nom },
                    Objet = new ItemModel { Id = (Guid)x.ObjetId, Nom = x.Objet.Nom },
                    Categorie = new ItemModel { Id = (Guid)x.CategorieId, Nom = x.Categorie.Nom },
                    Emplacement = new ItemModel { Id = (Guid)x.LocalisationId, Nom = x.Localisation.Nom },
                    TypeBatiment = new ItemModel { Id = (Guid)x.TypeBatimentId, Nom = x.TypeBatiment.Nom },
                    TypeDomage = new ItemModel { Id = (Guid)x.TypeDomageId, Nom = x.TypeDomage.Nom },
                    RendezVous = new ItemModel { Id = (Guid)x.TypeRendezVousId, Nom = x.TypeRendezVous.Nom },
                    Reparateur = _databaseContext.Utilisateurs
                            .Where(u => u.Id == x.ReparateurId)
                            .Select(u => new ItemModel { Id = u.Id, Nom = u.Nom + " " + u.Prenom })
                            .FirstOrDefault(),
                    Debut = x.Debut,
                    UserInfo = new UtilisateurModel
                    {
                        Id = (Guid)x.Id,
                        Nom = x.Utilisateurs.Nom,
                        Prenom = x.Utilisateurs.Prenom,
                        Age = x.Utilisateurs.Age,
                        NumMaison = x.Utilisateurs.NumMaison,
                        Delegations = new DelegationModel { Id = (Guid)x.Id, Nom = x.Utilisateurs.Delegations.Nom },
                        Gouvernorats = new GouvernoratModel { Id = (Guid)x.Utilisateurs.Delegations.Gouvernorat.Id, Nom = x.Utilisateurs.Delegations.Gouvernorat.Nom },
                        NumTelephone1 = x.Utilisateurs.NumeroTelephone1,
                        NumTelephone2 = x.Utilisateurs.NumeroTelephone2,
                        Rue = x.Utilisateurs.Rue,
                      
                    }
                })
                .FirstOrDefault();
        }



        public void UpdateStatus(Guid? statusId, Guid? dossierId)
        {
            // Récupérer le dossier à mettre à jour
            var dossierToUpdate = _databaseContext.Dossiers
                .FirstOrDefault(x => x.Id == dossierId);

            if (dossierToUpdate != null)
            {
                // Mettre à jour l'ID du statut
                dossierToUpdate.DossierStatusId = statusId;

                // Enregistrer les modifications dans la base de données
                _databaseContext.SaveChanges();
            }
        }
        public void RejeterDossier(Guid? dossierId)
        {
            var dossier = _databaseContext.Dossiers
                .FirstOrDefault(x => x.Id == dossierId);

            if (dossier != null)
            {
                dossier.ReparateurId = null;
             

                // Suppression de l'événement associé au dossier
                var eventToDelete = _databaseContext.Event.FirstOrDefault(e => e.DossierId == dossierId);
                if (eventToDelete != null)
                {
                    _databaseContext.Event.Remove(eventToDelete);
                }

                _databaseContext.SaveChanges();
            }
        }
        public void DeleteDossier(Guid? dossierId)
        {
            _databaseContext.Event.RemoveRange(_databaseContext.Event.Where(x => x.DossierId == dossierId));
           
            // Ajoutez d'autres tables selon vos besoins

            // Ensuite, supprimez le dossier lui-même
            var doss = _databaseContext.Dossiers.FirstOrDefault(x => x.Id == dossierId);
            if (doss != null)
            {
                _databaseContext.Dossiers.Remove(doss);
                _databaseContext.SaveChanges();
            }
        }


    }
}
