using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class TypeRendezVous
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string code { get; set; }
        public string CreePar { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
