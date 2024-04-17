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
        private static DatabaseContext _databaseContext;
        public DossierRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

        }

       

        public Dossier AddDossier(ReclamationModel Dossier)
        {
            // var utilisateur = _databaseContext.Utilisateurs.FirstOrDefault(u => u.Email == Dossier.CreatedBy);
            var statusId = _databaseContext.DossierStatus.FirstOrDefault(x => x.code == "").Id ;
            var newDossier = new Dossier()
            {

                Id = Guid.NewGuid(),
                UtilisateurId = Dossier.UtilisateurId,
                IsEmergency = Dossier.Damage.IsEmergency,
                CategorieId = Dossier.Categorie.Id,
                CauseId = Dossier.Damage.Cause.Id,
                DossierStatusId = statusId,
                LocalisationId = Dossier.Damage.Localisation.Id,
                MaterielId = Dossier.Damage.Localisation.Id,
                ObjetId = Dossier.Damage.Objets.Id,
                TypeBatimentId = Dossier.Damage.BuildingType.Id,
                TypeDomageId = Dossier.Damage.TypeDomage.Id,
                Description=Dossier.Damage.Description,
                TypeRDV = Dossier.ChoixReparateur.RendezVous.Nom,
                CreatedDate =DateTime.Now,
                CreatedBy = Dossier.Email,


            };

            _databaseContext.Dossiers.Add(newDossier);


            _databaseContext.SaveChangesAsync();

            return newDossier;
        }

        public List<DossierModel> GetDossierById(Guid? Utilisateurid)
        {
            return _databaseContext.Dossiers.Where(x => x.UtilisateurId == Utilisateurid).Select(x => new DossierModel()
            {
                Id = x.Id,
                UtilisateurId = x.UtilisateurId,
                IsEmergency = x.IsEmergency,
                CategorieId = x.CategorieId,
                CauseId = x.CauseId,
                DossierStatusId = x.DossierStatusId,
                LocalisationId = x.LocalisationId,
                MaterielId = x.MaterielId,
                ObjetId = x.ObjetId,
                TypeBatimentId = x.TypeBatimentId,
                TypeDomageId = x.TypeDomageId,
                DossierNumber = x.DossierNumber,
               
                CreatedDate = x.CreatedDate,
                LastModificationBy = x.LastModificationBy,
                CreatedBy = x.Utilisateur.Email,

            }).ToList();
        }

       
    }
    


}
