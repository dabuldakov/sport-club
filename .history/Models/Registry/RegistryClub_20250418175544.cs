namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public long ClubId { get; set; }
    public long AthletId { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public required Club Club { get; set; }
    public required Athlet Athlet { get; set; }
}
