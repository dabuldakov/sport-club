namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public long ClubId { get; set; }
    public long AthletId { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public Club Club { get; set; } = null!;
    public Athlet Athlet { get; set; } = null!;
}
