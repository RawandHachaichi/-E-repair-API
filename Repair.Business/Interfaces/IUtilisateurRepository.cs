
using Repair.Business.Models;
using Repair.Database.Entities;


namespace Repair.Business.Interfaces
{
    public interface IUtilisateurRepository
    {
        public  Utilisateur AddUser(UtilisateurModel User);
        public Utilisateur Login(string Email, string Mdp);
        public List<ItemModel> GetReparateur( Guid delegationId,  Guid categorieId);
        public void UpdateUser(UtilisateurModel user);

         public void DeleteUser(Guid id);

    }
}
            

