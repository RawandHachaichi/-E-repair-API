using Repair.Business.Interfaces;
using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class UtilisateurModel 
    { 
        public Guid? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? MotDePasse { get; set; }
        public int? NumTelephone1 { get; set; }
        public int? Age { get; set; }
        public int? NumTelephone2 { get; set; }
        public string ?Role { get; set; }
        public DelegationModel? Delegations { get; set; }
        public List<Guid>? Competences { get; set; }
        public GouvernoratModel? Gouvernorats { get; set; }
        public string? Rue { get; set; }
        public int? NumMaison { get; set; }
        public Guid ReparateurId { get; set; }




    }
}
