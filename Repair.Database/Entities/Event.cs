using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Description { get; set; }
        public Guid? UtilisateurId { get; set; }
        public Utilisateur utilisateur { get; set; }
        public Guid TypeRendezVousId { get; set; }
        public TypeRendezVous TypeRendezVous { get; set; }
    }
}
