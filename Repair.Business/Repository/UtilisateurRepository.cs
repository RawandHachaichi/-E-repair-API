using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;


namespace Repair.Business.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private static DatabaseContext _databaseContext;
        //private IConfiguration _configuration;
        public UtilisateurRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            //_configuration = _configuration;
        }

        public Utilisateur AddUser(UtilisateurModel User)
        {
            try
            {

                // Hash the password
                var passwordHasher = new PasswordHasher<Utilisateur>();
                var hashedPassword = passwordHasher.HashPassword(new Utilisateur(), User.MotDePasse);

                var newUser = new Utilisateur()
                {
                    Id = Guid.NewGuid(),
                    Nom = User.Nom,
                    Prenom = User.Prenom,
                    Email = User.Email,
                    MotDePasse = hashedPassword,
                    Role = User.Role,
                    NumMaison = User.NumMaison,
                    Rue = User.Rue,
                    Age = User.Age,
                    DelegationId = User.Delegations.Id,
                    NumeroTelephone1 = User.NumTelephone1,
                    NumeroTelephone2 = User.NumTelephone2,
                    CreePar = User.Email,
                    DateCreation = DateTime.Now,
                };
                if (User.Role == "reparateur")
                {
                    foreach (var compId in User.Competences)
                    {
                        var comp = new ReparateurCompetence
                        {
                            CompetenceId = compId,
                            UtilisateurId = newUser.Id,

                        };
                        _databaseContext.ReparateurCompetences.Add(comp);

                    }
                }

                // Ajouter l'utilisateur à la base de données
                _databaseContext.Utilisateurs.Add(newUser);

                // Enregistrer les modifications dans la base de données

                _databaseContext.SaveChangesAsync();

                return newUser;


            }

            catch (Exception ex)
            {
                return null;

            }


        }

        // for login
        public Utilisateur Login(string Email, string Mdp)
        {
            // Recherche de l'utilisateur dans la base de données en fonction de l'email et du mot de passe fournis.
            var utilisateur = _databaseContext.Utilisateurs.FirstOrDefault(x => x.Email == Email && x.MotDePasse == Mdp);
            if (utilisateur == null)
            {
                // Si l'utilisateur n'est pas trouvé, retourne null, indiquant que l'authentification a échoué.

                return null;
            }
            else return utilisateur;

        }

        /* public string GenererToken()
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
