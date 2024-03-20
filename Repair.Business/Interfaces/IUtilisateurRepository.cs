using Microsoft.AspNetCore.Mvc;
using Repair.Business.Models;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Interfaces
{
    public interface IUtilisateurRepository
    {
        public  Utilisateur AddUser(UtilisateurModel User);
        public Utilisateur Login(string Email, string Mdp);
    }
}
            

