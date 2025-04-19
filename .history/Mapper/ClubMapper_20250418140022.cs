using SportClubApi.Models;

namespace SportClubApi.Mapper;

public class ClubMapper
{
    public Club ToDtoCreate(ClubDtoCreate dto) {
   var club = new Club(
        dto.Name,
        dto.Description,
        dto.SportTypeId,
        dto.MaxAthletes
    );
    
    return club;
    }
}
