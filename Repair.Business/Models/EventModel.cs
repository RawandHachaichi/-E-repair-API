using Repair.Business.Models;

public class RendezVousModel
{
    public Guid Id { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public ItemModel TypeRendezVous { get; set; }
    public string? Description { get; set; }
    public Guid? UserId { get; set; }
    public Guid? DossierId { get; set; }
   public Guid? ReparateurId { get; set; }
  
}