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

                var newUser = new Utilisateur()
                {
                    Id = Guid.NewGuid(),
                    Nom = user.Nom,
                    Prenom = user.Prenom,
                    Email = user.Email,
                    MotDePasse = user.MotDePasee,
                    Role = user.Role,
                    NumeroTelephone1 = user.NumTelephone1,
                    NumeroTelephone2 = user.NumTelephone2,
                    NumMaison = user.NumMaison,
                    Rue = user.Rue,
                    Age = user.Age,
                    DelegationId = user.DelegationId
                    

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
        
    }
}
