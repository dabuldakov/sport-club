namespace SportClubApi.Dto;

public class ExclusionDocumentDto
{
    public long Id { get; set; }
    public required string Number { get; set; }
    public required DateTime Date { get; set; }
    public string Comment { get; set; } = null!;
    public required long CreatorId { get; set; }
    public required long ClubId { get; set; }
    public required long AthletId { get; set; }
}
