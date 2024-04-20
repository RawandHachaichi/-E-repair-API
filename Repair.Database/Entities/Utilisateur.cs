using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Utilisateur
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string MotDePasse { get; set; }
        public int? NumeroTelephone1 { get; set; }
        public int? NumeroTelephone2 { get; set; }
        public string Role { get; set; }

        public string? Rue { get; set; }
        public int? NumMaison { get; set; }
        public string CreePar { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid DelegationId { get; set; } //foreign Key
        public Delegation Delegation { get; set; }
        public Collection<ReparateurCompetence> ReparateurCompetances { get; set; }

        
        
    }
}
