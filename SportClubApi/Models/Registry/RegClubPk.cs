namespace SportClubApi.Models.Registry;

public class RegClubPk(long ClubId, long AthletId)
{
    public long ClubId { get; set; } = ClubId;
    public long AthletId { get; set; } = AthletId;
}
