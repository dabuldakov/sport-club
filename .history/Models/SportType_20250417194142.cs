namespace SportClubApi.Models;

public class SportType
{
    public long id;
    public required string Name {get; set;}

    public ICollection<Club> Clubs { get; } = [];
}
