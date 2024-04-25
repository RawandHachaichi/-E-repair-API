
using Microsoft.AspNetCore.Mvc;
using Repair.Business.Models;
using Repair.Database.Entities;
using System.ComponentModel.DataAnnotations;


namespace Repair.Business.Interfaces
{
    public interface IUtilisateurRepository
    {
        public  Utilisateur AddUser(UtilisateurModel User);
        public Utilisateur Login(string email, string motDePasse);
        public List<ItemModel> GetReparateur( Guid delegationId,  Guid categorieId);
        public void UpdateUser(UtilisateurModel user);

         public void DeleteUser(Guid id);

    }
}
            

