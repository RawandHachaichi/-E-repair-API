using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class DocumentModel
    {
        public Guid Id { get; set; }
        public string NomFichier { get; set; }
        public byte[] ContenuFichier { get; set; }
        public string TypeDocument { get; set; }
        public DateTime? DateCreation { get; set; } = DateTime.Now;
        public Guid? OptionId { get; set; }
        public string Email { get; set; }
        public string? Option { get; set; }
        public DateTime? DerniereModification { get; set; }
        public String CreePar { get; set; }
        public Guid? DossierId { get; set; }
        public DossierModel Dossier { get; set; }
    }
}
