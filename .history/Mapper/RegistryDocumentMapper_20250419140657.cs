using SportClubApi.Dto;
using SportClubApi.Models.Regisrty;

namespace SportClubApi.Mapper;

public class RegistryDocumentMapper
{
    public ExclusionDocument ToDomainExclusion(ExclusionDocumentDto dto)
    {
        return new ExclusionDocument
        {
            Id = dto.Id,
            Number = dto.Number,
            Date = DateTime.UtcNow,
            Comment = dto.Comment,
            CreatorId = dto.CreatorId,
            ClubId = dto.ClubId,
            AthletId = dto.AthletId
        };
    }

    public ExclusionDocumentDto ToDtoMembershipExclusion(ExclusionDocument domain)
    {
        return new ExclusionDocumentDto
        {
            Id = domain.Id,
            Number = domain.Number,
            Date = domain.Date,
            Comment = domain.Comment,
            CreatorId = domain.CreatorId,
            ClubId = domain.ClubId,
            AthletId = domain.AthletId
        };
    }

    public MembershipDocument ToDomainMembership(MembershipDocumentDto dto)
    {
        return new MembershipDocument
        {
            Id = dto.Id,
            Number = dto.Number,
            Date = DateTime.UtcNow,
            Comment = dto.Comment,
            CreatorId = dto.CreatorId,
            ClubId = dto.ClubId,
            AthletId = dto.AthletId
        };
    }

    public MembershipDocumentDto ToDtoMembership(MembershipDocument domain)
    {
        return new MembershipDocumentDto
        {
            Id = domain.Id,
            Number = domain.Number,
            Date = domain.Date,
            Comment = domain.Comment,
            CreatorId = domain.CreatorId,
            ClubId = domain.ClubId,
            AthletId = domain.AthletId
        };
    }
}
