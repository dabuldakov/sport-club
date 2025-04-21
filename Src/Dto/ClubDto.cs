namespace SportClubApi.Models;

public class ClubDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required long SportTypeId { get; set; }
    public required int MaxAthletes { get; set; }
}
