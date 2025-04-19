namespace SportClubApi.Models;

public class Club
{
    public long Id {get; set;}
    public required string Name { get; set; }
    public required string Description { get; set; }
    public long SportTypeId { get; set; } 
    public int MaxAthletes { get; set; }

    public Club(string Name, string Description, long SportTypeId, int MaxAthletes) 
    {
        this.Name = Name;
        this.Description = Description;
        this.SportTypeId = SportTypeId;
        this.MaxAthletes = MaxAthletes;
    }
}
