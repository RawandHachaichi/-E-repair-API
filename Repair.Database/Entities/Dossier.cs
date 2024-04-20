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
        public string? DossierNumber { get; set; }
        public string CreePar { get; set; }
        public Guid? ReparateurId { get; set; }
        public Guid? UtilisateurId { get; set; }
        public Utilisateur Utilisateurs { get; set; }
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
        public Guid? MatiereId { get; set; }
        public Matiere Matiere{ get; set; }
        public Guid? LocalisationId { get; set; }
        public Localisation Localisation { get; set; }

        public bool? Urgent { get; set; }=false;
        public string? Description { get; set; }

        public Guid? TypeRendezVousId { get; set; }
        public TypeRendezVous TypeRendezVous{ get; set; }
        public DateTime? DateCreation { get; set; } = DateTime.Now;
        public Guid? DerniereModification { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin{ get; set; }

    }
}
