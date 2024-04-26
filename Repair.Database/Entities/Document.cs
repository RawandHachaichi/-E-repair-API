using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string NomFichier { get; set; }
        public byte[] ContenuFichier { get; set; }
        public DateTime? DateCreation{ get; set; } 
        public String ExtensionDoc { get; set; }
        public String CreePar{ get; set; }
        public Guid? DossierId { get; set; } // propriété pour l'ID du dossier
        public Dossier? Dossier { get; set; }
        public Guid TypeDocumentId { get; set; }
        public TypeDocument TypeDocument { get; set; }
    }
}
