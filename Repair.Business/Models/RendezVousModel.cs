using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class RendezVousModel
    {
        public ItemModel? TypeRendezVous { get; set; }
        public string? Description{ get; set; }
        public DateTime? Start { get; set; } = DateTime.Now;

        public DateTime? End { get; set; } = DateTime.Now;
    }
}
