namespace SportClubApi.Models;

public class MembershipDocument
{
    public long Id { get; set; }
    public required string Number { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; } = null!;
    public long CreatorId { get; set; }

}
