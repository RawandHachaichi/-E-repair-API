using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Reclamation
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
    }
}
