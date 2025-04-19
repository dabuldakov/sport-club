using System.ComponentModel.DataAnnotations;

namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    [Key]
    public required RegClubKey RegClubKey {get; set;}
    public long ClubId { get; set; }
    public long AthletId { get; set; }
    public DateTime CreateDate { get; set; }

    public required Club Club { get; set; }
    public required Athlet Athlet { get; set; }
}
