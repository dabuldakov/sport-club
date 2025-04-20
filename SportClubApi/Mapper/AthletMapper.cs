using SportClubApi.Models;

namespace SportClubApi.Mapper;

public class AthletMapper
{
    public AthletDto ToDto(Athlet athlet)
    {
        var dto = new AthletDto
        {
            Id = athlet.ID,
            Fio = athlet.Fio,
            SportTypeId = athlet.SportTypeID,
            ExpirenceWorkDays = athlet.ExpirenceWorkDays
        };
        return dto;
    }

    public Athlet ToDomain(AthletDto dto)
    {
        var athlet = new Athlet
        {
            ID = dto.Id,
            Fio = dto.Fio,
            SportTypeID = dto.SportTypeId,
            ExpirenceWorkDays = dto.ExpirenceWorkDays
        };
        return athlet;
    }
}
