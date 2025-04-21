namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public required long ClubID { get; set; }
    public required long AthletID { get; set; }
    public required DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public Club Club { get; set; } = null!;
    public Athlet Athlet { get; set; } = null!;
}
