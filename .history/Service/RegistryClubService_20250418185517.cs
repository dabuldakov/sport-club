using SportClubApi.Models.Regisrty;
using SportClubApi.Repositoory;

namespace SportClubApi.Service;

public class RegistryClubService(MembershipRepository membershipRepository, ExcclusionRepository excclusionRepository)
{
    private readonly MembershipRepository _membershipRepository = membershipRepository;
    private readonly ExcclusionRepository _exclusionRepository = excclusionRepository;

    public void SaveMembershipDocument(MembershipDocument document)
    {
        _membershipRepository.Save(document);
    }

    public void SaveExclusionDocument(ExclusionDocument document)
    {
        _exclusionRepository.Save(document);
    }
}
