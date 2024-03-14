using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;
using Repair.Database.Entities;

namespace RepairAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private static IUtilisateurRepository _IUtilisateurRepository;
        public UtilisateurController(IUtilisateurRepository UtilisateurRepository)
        {
            _IUtilisateurRepository = UtilisateurRepository;
        }
       
        [HttpPost]
        public Task<String> Register(UtilisateurModel user)
        {
            return _IUtilisateurRepository.AddUser(user);

        }


    }
}
