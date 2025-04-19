namespace SportClubApi.Models;

public class Club
{
    public long Id {get; set;}
    public required string Name { get; set; }
    public required string Description { get; set; }
    public long SportTypeId { get; set; } 
    public int MaxAthletes { get; set; }
}
