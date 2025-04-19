namespace SportClubApi.Models;

public class SportType
{
    public long Id {get; set;}
    public required string Name {get; set;}

    public ICollection<Club> Clubs { get; } = [];
    public ICollection<Athlet> Athlets { get; } = [];
}
