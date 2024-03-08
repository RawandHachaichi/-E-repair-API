using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Competance
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string? Code { get; set; }
        public string CreePar { get; set; }
        public DateTime DateCreation { get; set; }
        public List<ReparateurCompetance> ReparateurCompetances{ get; set; }

    }
}
