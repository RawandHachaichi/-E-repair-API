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

       

        public Dossier AddDossier(DossierModel Dossier)
        {
            var utilisateur = _databaseContext.Utilisateurs.FirstOrDefault(u => u.Email == Dossier.CreatedBy);

            var newDossier = new Dossier()
            {

                Id = Dossier.Id,
                UtilisateurId = Dossier.UtilisateurId,
                IsEmergency = Dossier.IsEmergency,
                CategorieId = Dossier.CategorieId,
                CauseId = Dossier.CauseId,
                DossierStatusId = Dossier.DossierStatusId,
                LocalisationId = Dossier.LocalisationId,
                MaterielId = Dossier.MaterielId,
                ObjetId = Dossier.ObjetId,
                TypeBatimentId = Dossier.TypeBatimentId,
                TypeDomageId = Dossier.TypeDomageId,
                RendezVousId = Dossier.RendezVousId,
                DossierNumber = Dossier.DossierNumber,
                DateIncident = Dossier.DateIncident,
                CreatedDate = Dossier.CreatedDate,
                LastModificationBy = Dossier.LastModificationBy,
                CreatedBy = utilisateur.Email,


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
                RendezVousId = x.RendezVousId,
                DateIncident = x.DateIncident,
                CreatedDate = x.CreatedDate,
                LastModificationBy = x.LastModificationBy,
                CreatedBy = x.Utilisateur.Email,

            }).ToList();
        }

       
    }
    


}
