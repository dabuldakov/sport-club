using SportClubApi.Interface;
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Service;

public class RegistryClubService(
    IMembershipRepository membershipRepository,
    IExclusionRepository excclusionRepository,
    IRegistryClubRepository registryClubRepository)
{
    private readonly IMembershipRepository _membershipRepository = membershipRepository;
    private readonly IExclusionRepository _exclusionRepository = excclusionRepository;
    private readonly IRegistryClubRepository _registryClubRepository = registryClubRepository;

    public async Task<MembershipDocument> SaveMembershipDocument(MembershipDocument document)
    {
        var registry = new RegistryClub
        {
            AthletID = document.AthletID,
            ClubID = document.ClubID
        };
        var found = await _registryClubRepository.GetByAthletIdFirstAsync(document.AthletID);
        if (found != null)
        {
            throw new ArgumentException("Спортсмен уже добавлен в спортивный клуб.");
        }
        //transaction
        _membershipRepository.Save(document);
        _registryClubRepository.Save(registry);
        return document;
    }

    public async Task<ExclusionDocument> SaveExclusionDocument(ExclusionDocument document)
    {
        var found = await _registryClubRepository.GetByAthletIdFirstAsync(document.AthletID);
        if (found == null)
        {
            throw new ArgumentException("Спортсмен не принадлежит спортивному клубу.");
        }
        //transaction
        _exclusionRepository.Save(document);
        _registryClubRepository.Delete(found);
        return document;
    }

    public Task<List<Athlet>> GetAthletsInClub(long clubId)
    {
        return _registryClubRepository.GetAthletsByClubIdAsync(clubId);
    }
}
