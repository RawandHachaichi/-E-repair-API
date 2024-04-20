using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Repository
{
    public class DossierRepository : IDossierRepository
    {
        private static int _nextDossierNumber = 1;
        private static DatabaseContext _databaseContext;
        public DossierRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private string GenerateDossierNumber()
        {
            // Utilisez _nextDossierNumber pour obtenir le prochain numéro de dossier
            int  count =_databaseContext.Dossiers.Count() +1;
            var dossierNumber = "DOS2014T" + count;
            return dossierNumber;
        }

        public Dossier AddDossier(ReclamationModel Dossier)
        {
            try
            {
               // var Reparateur = _databaseContext.Utilisateurs.FirstOrDefault(x => x.Role == "reparateur").Id;
                var statusId = _databaseContext.DossierStatus.FirstOrDefault(x => x.code == "AP").Id;

                var newDossier = new Dossier()
                {
                    Id = Guid.NewGuid(),
                    DossierNumber = GenerateDossierNumber(), // Utilisation de la méthode pour générer le numéro de dossier
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
                    UtilisateurId =Dossier.UtilisateurId,
                    ReparateurId = Dossier.ChoixReparateur.Reparateur.Id,
                    Debut =Dossier.ChoixReparateur.RendezVous.Start,
                    Fin=Dossier.ChoixReparateur.RendezVous.End,
                    
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

        public List<DossierModel> GetDossierByUserId(Guid? Utilisateurid)
        {
            var res= _databaseContext.Dossiers.Include(x=>x.DossierStatus).Where(x=>x.UtilisateurId==Utilisateurid)
                
                .Select(x => new DossierModel()
            {
                Id = x.Id,
                Urgent = (bool)x.Urgent?"Oui":"Non",
                DossierStatus = new ItemModel { Id= (Guid)x.DossierStatusId,Nom=x.DossierStatus.Nom},
                DossierNumber = x.DossierNumber,
                CreePar= x.CreePar,
                DateCreation=x.DateCreation
            }).ToList();
            return res;
        }
    }
}
