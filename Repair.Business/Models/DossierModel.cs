using Repair.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models
{
    public class DossierModel
    {
        public Guid Id { get; set; }
        public int? DossierNumber { get; set; }
        public Guid? DossierStatusId { get; set; }
        public Guid? UtilisateurId { get; set; }
        public Guid? CategorieId { get; set; }
     
        public Guid? CauseId { get; set; }
     
        public Guid? ObjetId { get; set; }
       
        public Guid? TypeBatimentId { get; set; }
  
        public Guid? TypeDomageId { get; set; }
     
        public Guid? MaterielId { get; set; }
        public Guid? RendezVousId { get; set; }
    
        public Guid? LocalisationId { get; set; }
        public bool? IsEmergency { get; set; }
        public DateTime? DateIncident { get; set; }
        public bool? Active { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? LastModificationBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
