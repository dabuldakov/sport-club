using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    [Key]
    public required RegClubKey RegClubKey {get; set;}
    [ForeignKey(nameof(Club))]
    public long ClubId { get; set; }
    [ForeignKey(nameof(Athlet))]
    public long AthletId { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow; 

    public required Club Club { get; set; }
    public required Athlet Athlet { get; set; }
}
