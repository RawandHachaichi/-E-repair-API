using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class Dossier
    {
        [Key]
        public Guid Id { get; set; }
        public int? DossierNumber { get; set; }
        public string CreatedBy { get; set; }
        public Guid? UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Guid? DossierStatusId { get; set; }
        public DossierStatus DossierStatus { get; set; }
        public Guid? CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public Guid? CauseId { get; set; }
        public Cause Cause { get; set; }
        public Guid? ObjetId { get; set; }
        public Objet Objet { get; set; }
        public Guid? TypeBatimentId { get; set; }
        public TypeBatiment TypeBatiment { get; set; }
        public Guid? TypeDomageId { get; set; }
        public TypeDomage TypeDomage { get; set; }
        public Guid? MaterielId { get; set; }
        public Matiere Matiere{ get; set; }
        public Guid? LocalisationId { get; set; }
        public Localisation Localisation { get; set; }

        public bool? IsEmergency { get; set; }
        public string? Description { get; set; }
        // public DateTime? DateIncident { get; set; }

        public string? TypeRDV { get; set; }
        public TypeRendezVous TypeRendezVous{ get; set; }
        public bool? Active { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? LastModificationBy { get; set; }

    }
}
