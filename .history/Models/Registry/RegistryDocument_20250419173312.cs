namespace SportClubApi.Models.Regisrty;

public class RegistryDocument
{
    public long ID { get; set; }
    public required string Number { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; } = null!;
    public long CreatorId { get; set; }
    public long ClubID { get; set; }
    public long AthletID { get; set; }
}
