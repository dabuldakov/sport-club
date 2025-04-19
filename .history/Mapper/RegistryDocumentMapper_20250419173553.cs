using SportClubApi.Dto;
using SportClubApi.Models.Regisrty;

namespace SportClubApi.Mapper;

public class RegistryDocumentMapper
{
    public ExclusionDocument ToDomainExclusion(ExclusionDocumentDto dto)
    {
        return new ExclusionDocument
        {
            ID = dto.Id,
            Number = dto.Number,
            Date = DateTime.UtcNow,
            Comment = dto.Comment,
            CreatorId = dto.CreatorId,
            ClubID = dto.ClubId,
            AthletID = dto.AthletId
        };
    }

    public ExclusionDocumentDto ToDtoExclusion(ExclusionDocument domain)
    {
        return new ExclusionDocumentDto
        {
            Id = domain.ID,
            Number = domain.Number,
            Date = domain.Date,
            Comment = domain.Comment,
            CreatorId = domain.CreatorId,
            ClubId = domain.ClubID,
            AthletId = domain.AthletID
        };
    }

    public MembershipDocument ToDomainMembership(MembershipDocumentDto dto)
    {
        return new MembershipDocument
        {
            ID = dto.Id,
            Number = dto.Number,
            Date = DateTime.UtcNow,
            Comment = dto.Comment,
            CreatorId = dto.CreatorId,
            ClubID = dto.ClubId,
            AthletID = dto.AthletId
        };
    }

    public MembershipDocumentDto ToDtoMembership(MembershipDocument domain)
    {
        return new MembershipDocumentDto
        {
            Id = domain.ID,
            Number = domain.Number,
            Date = domain.Date,
            Comment = domain.Comment,
            CreatorId = domain.CreatorId,
            ClubId = domain.ClubID,
            AthletId = domain.AthletID
        };
    }
}
