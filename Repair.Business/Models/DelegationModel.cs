using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class DelegationModel
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string? Code { get; set; }
      
    }
}
