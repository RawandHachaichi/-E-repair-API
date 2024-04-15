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
        public Dossier AddDossier(DossierModel Dossier);
        public List<DossierModel> GetDossierById(Guid? UtilisateurId);
    }
}
