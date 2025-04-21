namespace SportClubApi.Models.Registry;

public class RegistryDocument
{
    public long ID { get; set; }
    public required string Number { get; set; }
    public required DateTime Date { get; set; }
    public string Comment { get; set; } = null!;
    public required long CreatorId { get; set; }
    public required long ClubID { get; set; }
    public required long AthletID { get; set; }
}
