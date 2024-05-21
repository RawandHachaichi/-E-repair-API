using Repair.Business.Models;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Interfaces
{
    public interface IDossierRepository
    {
        public Dossier AddDossier(ReclamationModel Dossier);
        public List<DossierModel> GetDossierByUserId(Guid? Utilisateurid, string role);
        public DossierModel GetDossierById(Guid? id);
        public void UpdateStatus(Guid? statusId, Guid? dossierId);
        public void RejeterDossier(Guid? dossierId);
        public void DeleteDossier(Guid? dossierId);

    }
}
