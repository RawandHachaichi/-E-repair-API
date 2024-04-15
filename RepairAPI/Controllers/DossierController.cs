﻿using Microsoft.AspNetCore.Http;
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
        public Dossier AddDossier(DossierModel Dossier)
        {
            return _IDossierRepository.AddDossier(Dossier);
        }

        [HttpGet]
        [Route("/Dossier/{UtilisateurId}")]
        public List<DossierModel> GetDossierById(Guid? UtilisateurId)
        {
            return _IDossierRepository.GetDossierById(UtilisateurId);
        }
    }
   
}


