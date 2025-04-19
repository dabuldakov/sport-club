namespace SportClubApi.Dto;

public class MembershipDocumentDto
{
    public required string Number { get; set; }
    public string Comment { get; set; } = null!;
    public long CreatorId { get; set; }
    public long ClubId { get; set; }
    public long AthletId { get; set; }
}
