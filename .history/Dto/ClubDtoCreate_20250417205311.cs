namespace SportClubApi.Models;

public class ClubDtoCreate
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public long SportTypeId { get; set; } 
    public int MaxAthletes { get; set; }
}
