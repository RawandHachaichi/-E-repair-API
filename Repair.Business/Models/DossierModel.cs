using Microsoft.AspNetCore.Identity;
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
        public String? DossierNumber { get; set; }
        public ItemModel DossierStatus { get; set; }
        public Guid? UtilisateurId { get; set; }
        public ItemModel? Categorie { get; set; }
     
        public ItemModel? Cause { get; set; }
     
        public ItemModel? Objet { get; set; }
       
        public ItemModel? TypeBatiment { get; set; }
  
        public ItemModel? TypeDomage { get; set; }
     
        public ItemModel? Matiere { get; set; }
        public ItemModel? RendezVous { get; set; }
    
        public ItemModel? Emplacement { get; set; }
        public string? Urgent { get; set; }
        public DateTime? DateCreation { get; set; } 
        public Guid? DerniereModification { get; set; }
        public DateTime Debut { get; set; }
        //public DateTime Fin { get; set; }
        public string CreePar { get; set; }
        public ItemModel Reparateur { get; set; }
        public UtilisateurModel UserInfo { get; set; }
    }

    public class ReclamationModel
    {
        public Guid? UtilisateurId { get; set; }
        public string? Email { get; set; }

        public ItemModel? Categorie { get; set; }
        public UtilisateurModel Info  { get; set; }

        public DamageInformationModel? Damage  { get; set; }
       // public  ItemModel? Plannification { get; set; }

        public ReparateurRendezVousModel? ChoixReparateur { get; set; }

    }
      public class DamageInformationModel
      {
        public ItemModel? Cause { get; set; }
        public ItemModel? BuildingType { get; set; }
        public ItemModel? TypeDomage { get; set; }
        public ItemModel? Localisation { get; set; }
        public ItemModel? Objets { get; set; }
        public ItemModel? Matiere { get; set; }
        public string? Description { get; set; }
        public Boolean? IsEmergency { get; set; } = false;
      }
   

    public class ReparateurRendezVousModel
    {
        public ItemModel? Reparateur { get; set; }
        public RRendezVousModel RendezVous { get; set; }
    }

    public class RRendezVousModel
    {
        public ItemModel? TypeRendezVous { get; set; }
         public string? Description { get; set; }
          public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }



}

