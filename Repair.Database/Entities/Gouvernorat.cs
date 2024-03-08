
using System.ComponentModel.DataAnnotations;

namespace E_repair.Models
{
    public class Gouvernorat
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Code { get; set; }
        public string CreePar { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
