using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class CategorieComp
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategorieId { get; set; }
        public Categorie Categories { get; set; }

        public Guid CompetenceId { get; set; }
        public Competence Competences { get; set; }


    }
}
