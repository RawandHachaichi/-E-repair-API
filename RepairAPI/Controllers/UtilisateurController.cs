using Microsoft.AspNetCore.Authorization;
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
       
        [HttpPost("/register")]
        public Utilisateur Register(UtilisateurModel user)
        {
            return _IUtilisateurRepository.AddUser(user);

        }

        [Authorize] 
        [HttpPost("/login/{Email};{mdp}")]
        public ActionResult Login(string Email, string Mdp)
        {
          // Appel de la méthode de login du repository utilisateur pour tenter de s'authentifier.
            var res = _IUtilisateurRepository.Login(Email, Mdp);

            // Retourne une réponse OK avec le résultat de l'authentification
            return Ok(res);
        }


    }

}
