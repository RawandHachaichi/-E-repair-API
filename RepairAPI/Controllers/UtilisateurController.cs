using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Business.Repository;
using Repair.Database.Entities;
using System.ComponentModel.DataAnnotations;

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

        
        [HttpPost("/login/{email};{motDePasse}")]
        public Utilisateur Login(string email, string motDePasse)
        {
           return _IUtilisateurRepository.Login(email, motDePasse);
        }

        


        [HttpGet("/GetReparateur/{delegationId}/{categorieId}")]
        public List<ItemModel> GetReparateur(Guid delegationId, Guid categorieId)
        {
            var res = _IUtilisateurRepository.GetReparateur(delegationId, categorieId);
            return res;
        }


        [HttpPut("/UpdateUser")]
        public void UpdateUser(UtilisateurModel user)
        {
             _IUtilisateurRepository.UpdateUser(user);
        }

        [HttpDelete("/RemoveUser/{id}")]

        public void DeleteUser(Guid id)
        {
            _IUtilisateurRepository.DeleteUser(id);
        }


        /*public string GenererToken()
         {
             // Obtenir la clé secrète depuis la configuration
             var cleSecrete = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

             // Créer des informations d'identification en utilisant la clé secrète et l'algorithme HMAC-SHA256
             var informationsIdentification = new SigningCredentials(cleSecrete, SecurityAlgorithms.HmacSha256);

             // Définir les revendications pour le jeton
             var revendications = new[]
             {
               // Revendication de sujet, généralement le nom d'utilisateur ou un identifiant unique
              new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:id"]),

                // Revendication ID JWT, un identifiant unique pour le jeton
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // Revendication d'émission, l'horodatage lorsque le jeton a été émis
                 new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                 // Revendications personnalisées supplémentaires, telles que l'ID utilisateur et le rôle
                new Claim("Id", _databaseContext.Utilisateurs.FirstOrDefault(x => x.Email == "votre_email_ici")?.Id.ToString()),

             };

             // Créer un JWT avec l'émetteur spécifié, les revendications, le temps d'expiration et les informations d'identification de signature
             var jeton = new JwtSecurityToken(
                 issuer: _configuration["Jwt:Issuer"],
                 audience: _configuration["Jwt:Issuer"], // L'audience est généralement identique à l'émetteur
                 claims: revendications,
                 expires: DateTime.Now.AddMinutes(120), // Temps d'expiration du jeton
                 signingCredentials: informationsIdentification);

             // Sérialiser le jeton en une chaîne
             var chaineJeton = new JwtSecurityTokenHandler().WriteToken(jeton);

             return chaineJeton;
         }*/


    }
}
