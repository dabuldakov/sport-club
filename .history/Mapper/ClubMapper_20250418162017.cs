using System.Runtime.CompilerServices;
using SportClubApi.Models;

namespace SportClubApi.Mapper;

public class ClubMapper
{
    public Club ToDomain(ClubDto dto)
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

    public ClubDto ToDto(Club club)
    {
        var dto = new ClubDto
        {
            Id = club.Id,
            Description = club.Description,
            Name = club.Name,
            MaxAthletes = club.MaxAthletes,
            SportTypeId = club.SportTypeId
        };

        return dto;
    }
}
