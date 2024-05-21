using Repair.Database.Entities;
using System.ComponentModel.DataAnnotations;

public class Event
{
    [Key]
    public Guid Id { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public string? Description { get; set; }
    public Guid TypeRendezVousId { get; set; }
    public TypeRendezVous TypeRendezVous { get; set; }
    public Guid? DossierId { get; set; }
    public Dossier dossier { get; set; }


}