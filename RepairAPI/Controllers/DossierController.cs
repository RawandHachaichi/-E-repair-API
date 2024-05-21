using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;
using Repair.Database.Entities;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierController : ControllerBase
    {
        private static IDossierRepository _IDossierRepository;

        public DossierController(IDossierRepository DossierRepository)
        {
            _IDossierRepository = DossierRepository;
        }
        [HttpPost]
        public Dossier AddDossier(ReclamationModel Dossier)
        {
            return _IDossierRepository.AddDossier(Dossier);
        }

        [HttpGet]
        [Route("/Dossier/{UtilisateurId}/{role}")]
        public List<DossierModel> GetDossierById(Guid? UtilisateurId, string role)
        {
            return _IDossierRepository.GetDossierByUserId(UtilisateurId, role);

        }

        [HttpGet]
        [Route("/GetDossier/{id}")]
        public DossierModel GetDossier(Guid? id)
        {
            return _IDossierRepository.GetDossierById(id);
        }


        [HttpPut("/UpdateStatus/{statusId}/{dossierId}")]
        public void UpdateStatus(Guid? statusId, Guid? dossierId)
        {

            _IDossierRepository.UpdateStatus(statusId, dossierId);

        }
        [HttpPut("/RejetDossier/{dossierId}")]
        public void RejeterDossier(Guid? dossierId)
        {
            _IDossierRepository.RejeterDossier(dossierId);
        }
        [HttpDelete ("/DeleteDossier/{dossierId}")]
                    public void DeleteDossier(Guid? dossierId)
                    {
                        _IDossierRepository.DeleteDossier(dossierId);
                    }


    }

}


