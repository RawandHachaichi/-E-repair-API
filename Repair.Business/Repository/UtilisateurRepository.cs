using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repair.Business.Interfaces;
using Repair.Business.Models;
using Repair.Database;
using Repair.Database.Entities;
using System;
using System.Data;

namespace Repair.Business.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private static DatabaseContext _databaseContext;
       
        public UtilisateurRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            
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
                        var comp = new ReparateurCompetence()
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

                _databaseContext.SaveChanges();

                return newUser;


            }

            catch (Exception ex)
            {
                return null;

            }


        }
        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            // Utiliser la méthode VerifyHashedPassword de PasswordHasher pour comparer le mot de passe haché avec le mot de passe fourni
            var passwordHasher = new PasswordHasher<Utilisateur>();
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);

            // Retourner vrai si la vérification est réussie, sinon retourner faux
            return result == PasswordVerificationResult.Success;
        }


        // for login
        public Utilisateur Login(string email, string motDePasse)
        {
            // Récupérer l'utilisateur de la base de données en fonction de l'e-mail fourni.
            var utilisateur = _databaseContext.Utilisateurs.FirstOrDefault(x => x.Email == email);

            if (utilisateur != null)
            {
                // Vérifier si le mot de passe fourni correspond au mot de passe de l'utilisateur trouvé.
                if (VerifyHashedPassword(utilisateur.MotDePasse, motDePasse))
                {
                    // Authentification réussie, retourner l'utilisateur trouvé.
                    return utilisateur;
                }
            }

            // Si l'utilisateur n'est pas trouvé ou si le mot de passe est incorrect, retourner null.
            return null;
        }


        public List<ItemModel> GetReparateur( Guid delegationId, Guid categorieId)
        {
            {
                
                var reparateurs = (
                    // Début de la requête LINQ pour sélectionner les utilisateurs
                    from rep in _databaseContext.Utilisateurs
                        // Filtrer les utilisateurs par l'identifiant de la délégation
                    // Joindre avec la table des compétences des réparateurs (clé étranger obligatoire)
                    join repComp in _databaseContext.ReparateurCompetences
                        on rep.Id equals repComp.UtilisateurId
                    // Joindre avec la table des compétences des catégories
                    join catComp in _databaseContext.CategorieComp
                        on repComp.CompetenceId equals catComp.CompetenceId
                    // Filtrer les utilisateurs par l'identifiant de la catégorie
                    where catComp.CategorieId == categorieId &&  rep.DelegationId == delegationId

                    // Sélectionner les propriétés nécessaires pour créer un UtilisateurModel
                    select new ItemModel
                    {
                        Id = rep.Id,
                        Nom = rep.Nom + " " + rep.Prenom

                // Ajoutez d'autres propriétés si nécessaire
            }
                // Convertir les résultats en une liste
                ).ToList();

                // Retourner la liste filtrée des utilisateurs
                return reparateurs;
            }

        }




        public void DeleteUser(Guid id)
        {

                // Récupérer l'utilisateur à supprimer de la base de données
                var user = _databaseContext.Utilisateurs.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    // Récupérer les entrées dans ReparateurCompetences liées à cet utilisateur
                    var reparateurCompetences = _databaseContext.ReparateurCompetences.Where(rc => rc.UtilisateurId == id).ToList();

                    // Supprimer les entrées de ReparateurCompetences liées à cet utilisateur
                    _databaseContext.ReparateurCompetences.RemoveRange(reparateurCompetences);

                    // Ensuite, supprimer l'utilisateur lui-même
                    _databaseContext.Utilisateurs.Remove(user);

                    // Appliquer les modifications à la base de données
                    _databaseContext.SaveChanges();
                }
            




        }

        public void UpdateUser(UtilisateurModel user)

        {
            // Vérifier si l'utilisateur existe dans la base de données
            var userToUpdate = _databaseContext.Utilisateurs.Where(x => x.Id == user.Id).FirstOrDefault();
           
            if (userToUpdate != null)
            {
                var passwordHasher = new PasswordHasher<Utilisateur>();
                var hashedPassword = passwordHasher.HashPassword(new Utilisateur(), userToUpdate.MotDePasse);

                var clientToUpdate = _databaseContext.Utilisateurs.Where(x => x.Id == userToUpdate.Id).FirstOrDefault();
                    clientToUpdate.Nom= user.Nom;
                    clientToUpdate.Prenom= user.Prenom;
                    clientToUpdate.Age = user.Age;
                    clientToUpdate.NumeroTelephone1 = user.NumTelephone1;
                    clientToUpdate.NumeroTelephone2 = user.NumTelephone2;
                    clientToUpdate.DelegationId= user.Delegations.Id;
                    clientToUpdate.Rue= user.Rue;
                    clientToUpdate.NumMaison = user.NumMaison;
                    clientToUpdate.Email = user.Email;
                    clientToUpdate.MotDePasse = hashedPassword;


            }
            if (userToUpdate.Role == "reparateur")
            {
                // Supprimer les compétences existantes du réparateur
                var existingCompetences = _databaseContext.ReparateurCompetences.Where(rc => rc.UtilisateurId == userToUpdate.Id);
                _databaseContext.ReparateurCompetences.RemoveRange(existingCompetences);

                // Ajouter les nouvelles compétences du réparateur
                foreach (var compId in user.Competences)
                {
                    var comp = new ReparateurCompetence()
                    {
                        CompetenceId = compId,
                        UtilisateurId = userToUpdate.Id,
                    };
                    _databaseContext.ReparateurCompetences.Add(comp);
                }
            }

            // Sauvegarder les modifications dans la base de données
            _databaseContext.SaveChanges();

        }
    }
}
