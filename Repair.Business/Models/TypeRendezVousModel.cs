using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class TypeRendezVousModel
    {
       
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string code { get; set; }
    
    }
}
