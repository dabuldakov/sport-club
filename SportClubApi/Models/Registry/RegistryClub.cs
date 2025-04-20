namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public long ClubID { get; set; }
    public long AthletID { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public Club Club { get; set; } = null!;
    public Athlet Athlet { get; set; } = null!;
}
