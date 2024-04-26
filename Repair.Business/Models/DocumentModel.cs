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
        public DateTime? DateCreation { get; set; } 
        public Guid? OptionId { get; set; }
        public string Email { get; set; }
        public string? Option { get; set; }
        public String CreePar { get; set; }
        public Guid? DossierId { get; set; }
        public DossierModel Dossier { get; set; }
        public ItemModel TypeDocument { get; set; }
        public string ExtensionDoc { get; set; }
    }
}
