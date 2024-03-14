using Microsoft.AspNetCore.Identity;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;

namespace Repair.Business.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private static DatabaseContext _databaseContext;
        public UtilisateurRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<string> AddUser(UtilisateurModel user)
        {
            try
            {

                // Hash the password
                var passwordHasher = new PasswordHasher<Utilisateur>();
                var hashedPassword = passwordHasher.HashPassword(new Utilisateur(), user.MotDePasse);

                var newUser = new Utilisateur()
                {
                    Id = Guid.NewGuid(),
                    Nom = user.Nom,
                    Prenom = user.Prenom,
                    Email = user.Email,
                    MotDePasse = hashedPassword,
                    Role = user.Role,
                    NumeroTelephone1 = user.NumTelephone1,
                    NumeroTelephone2 = user.NumTelephone2,
                    NumMaison = user.NumMaison,
                    Rue = user.Rue,
                    Age = user.Age,



                };

                // Ajouter l'utilisateur à la base de données
                await _databaseContext.Utilisateurs.AddAsync(newUser);

                // Enregistrer les modifications dans la base de données

                await _databaseContext.SaveChangesAsync();

                return "Utilisateur ajouté avec succès.";


            }

            catch (Exception ex)
            {
                return "Une erreur s'est produite lors de l'ajout de l'utilisateur.";

            }


        }

        // for login
        public  Utilisateur Login(string Email, string Mdp)
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
    }
  
       
}
