namespace SportClubApi.Models.Registry;

public class RegistryClub
{
    public long Id { get; set; }
    public long ClibId { get; set; }
    public long AthletId { get; set; }
    public DateTime CreateDate { get; set; }

    public required Club Club { get; set; }
    public required Athlet Athlet { get; set; }
}
