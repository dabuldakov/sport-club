using SportClubApi.Models.Regisrty;
using SportClubApi.Models.Registry;
using SportClubApi.Repositoory;

namespace SportClubApi.Service;

public class RegistryClubService(MembershipRepository membershipRepository, ExcclusionRepository excclusionRepository, RegistryClubRepository registryClubRepository)
{
    private readonly MembershipRepository _membershipRepository = membershipRepository;
    private readonly ExcclusionRepository _exclusionRepository = excclusionRepository;
    private readonly RegistryClubRepository _registryClubRepository = registryClubRepository;

    public void SaveMembershipDocument(MembershipDocument document)
    {
        _membershipRepository.Save(document);
        var registry = new RegistryClub {
            AthletId = document.AthletId,
            ClubId = document.ClubId
        };
        _registryClubRepository.Save()
    }

    public void SaveExclusionDocument(ExclusionDocument document)
    {
        _exclusionRepository.Save(document);
    }

    public void DeleteMembership(MembershipDocument document) {
        var found = _membershipRepository.Find(document) ?? throw new ArgumentNullException("Не удалось найди документ с id " + document.Id);
        _membershipRepository.Delete(found);
    }
}
