namespace SportClubApi.Dto;

public class ExclusionDocumentDto
{
    public long Id { get; set; }
    public required string Number { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; } = null!;
    public long CreatorId { get; set; }
    public long ClubId { get; set; }
    public long AthletId { get; set; }
}
