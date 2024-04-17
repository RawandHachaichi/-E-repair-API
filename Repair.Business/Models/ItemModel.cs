using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string? CreePar { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
