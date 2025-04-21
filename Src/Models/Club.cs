using SportClubApi.Models.Registry;

namespace SportClubApi.Models;

public class Club()
{
    public long ID { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required long SportTypeID { get; set; }
    public required int MaxAthletes { get; set; }
    public ICollection<RegistryClub> RegistryClubs { get; set; } = [];
}
