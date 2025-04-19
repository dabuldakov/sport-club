using SportClubApi.Models;

namespace SportClubApi.Mapper;

public class AthletMapper
{
    public AthletDto ToDto(Athlet athlet)
    {
        var dto = new AthletDto
        {
            Id = athlet.Id,
            Fio = athlet.Fio,
            SportTypeId = athlet.SportTypeId,
            ExpirenceWorkDays = athlet.ExpirenceWorkDays
        };
        return dto;
    }

    public Athlet ToDomain(AthletDto dto)
    {
        var athlet = new Athlet
        {
            Id = dto.Id,
            Fio = dto.Fio,
            SportTypeId = dto.SportTypeId,
            ExpirenceWorkDays = dto.ExpirenceWorkDays
        };
        return athlet;
    }
}
