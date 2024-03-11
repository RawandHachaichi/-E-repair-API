using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class ReparateurCompetence
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UtilisateurId { get; set; }
        public Utilisateur Utilisateurs { get; set; }

        public Guid CompetenceId { get; set; }
        public Competence Competences { get; set; }

    }
}
