using SportClubApi.Models;

namespace SportClubApi.Mapper;

public class ClubMapper
{
    public Club ToDtoCreate(ClubDtoCreate dto)
    {
        var club = new Club
        {
            Description = dto.Description,
            Name = dto.Name,
            MaxAthletes = dto.MaxAthletes,
            SportTypeId = dto.SportTypeId
        };

        return club;
    }
}
