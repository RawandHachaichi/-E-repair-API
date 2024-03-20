using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Delegation
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string CreePar { get; set; }
        public string? Code { get; set; }
        public DateTime DateCreation { get; set; }
      
        public Guid GouvernoratId { get; set; }//foreign key
        public Gouvernorat Gouvernorat { get; set; }
        public List<Utilisateur> Utilisateur { get; set; }

    }
}
