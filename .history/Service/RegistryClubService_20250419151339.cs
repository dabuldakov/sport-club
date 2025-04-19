using SportClubApi.Models.Regisrty;
using SportClubApi.Models.Registry;
using SportClubApi.Repositoory;

namespace SportClubApi.Service;

public class RegistryClubService(
    MembershipRepository membershipRepository,
    ExcclusionRepository excclusionRepository,
    RegistryClubRepository registryClubRepository)
{
    private readonly MembershipRepository _membershipRepository = membershipRepository;
    private readonly ExcclusionRepository _exclusionRepository = excclusionRepository;
    private readonly RegistryClubRepository _registryClubRepository = registryClubRepository;

    public MembershipDocument SaveMembershipDocument(MembershipDocument document)
    {
        var registry = new RegistryClub
        {
            AthletId = document.AthletId,
            ClubId = document.ClubId
        };
        var found = _registryClubRepository.Find(new RegClubPk(document.ClubId, document.AthletId));
        if (found != null)
        {
            throw new ArgumentNullException("Спортсмен уже добавлен в спортивный клуб.");
        }
        //transaction
        _membershipRepository.Save(document);
        _registryClubRepository.Save(registry);
        return document;
    }

    public ExclusionDocument SaveExclusionDocument(ExclusionDocument document)
    {
        var registry = new RegistryClub
        {
            AthletId = document.AthletId,
            ClubId = document.ClubId
        };
        var found = _registryClubRepository.Find(new RegClubPk(document.ClubId, document.AthletId));
        if (found == null)
        {
            throw new ArgumentNullException("Спортсмен не принадлежит спортивному клубу.");
        }
        //transaction
        _exclusionRepository.Save(document);
        _registryClubRepository.Delete(found);
        return document;
    }
}
