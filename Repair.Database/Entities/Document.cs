using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string TypeDocument { get; set; }
        public DateTime? DateCreation{ get; set; } = DateTime.Now;
        public Guid? OptionId { get; set; }
        public string? Option { get; set; }
        public String CreePar{ get; set; }
        public Guid? DossierId { get; set; } // propriété pour l'ID du dossier
        public Dossier? Dossier { get; set; }
    }
}
