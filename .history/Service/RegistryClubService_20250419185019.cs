using SportClubApi.Models;
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
            AthletID = document.AthletID,
            ClubID = document.ClubID
        };
        var found = _registryClubRepository.Find(new RegClubPk (document.ClubID, document.AthletID ));
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
        var found = _registryClubRepository.Find(new RegClubPk(document.ClubID, document.AthletID));
        if (found == null)
        {
            throw new ArgumentNullException("Спортсмен не принадлежит спортивному клубу.");
        }
        //transaction
        _exclusionRepository.Save(document);
        _registryClubRepository.Delete(found);
        return document;
    }

    public Task<List<Athlet>> GetAthletsInClub(long clubId) {
        return _registryClubRepository.GetAthletsByClubIdAsync(clubId);
    }
}
