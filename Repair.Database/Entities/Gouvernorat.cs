
using System.ComponentModel.DataAnnotations;

namespace Repair.Database.Entities
{
    public class Gouvernorat
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string? Code { get; set; }
        public string CreePar { get; set; }
        public DateTime DateCreation { get; set; }
        public ICollection<Delegation> Delegations { get; set; }
       
    }
}
