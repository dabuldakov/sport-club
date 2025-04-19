namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public required RegClubPk RegClubPk { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public Club Club { get; set; } = null!;
    public Athlet Athlet { get; set; } = null!;
}
