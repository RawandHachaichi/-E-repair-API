using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Database.Entities
{
    public class ReparateurCompetance
    {
        [Key]
        Guid Id { get; set; }
        Guid UtilisateurId { get; set; }
        Guid CompetanceId { get; set; }

    }
}
