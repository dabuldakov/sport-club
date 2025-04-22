using System.Transactions;
using SportClubApi.Interface;
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Service;

public class RegistryClubService(
    IMembershipRepository membershipRepository,
    IExclusionRepository excclusionRepository,
    IRegistryClubRepository registryClubRepository,
    IAthletRepository athletRepository,
    IClubRepository clubRepository)
{
    private readonly IMembershipRepository _membershipRepository = membershipRepository;
    private readonly IExclusionRepository _exclusionRepository = excclusionRepository;
    private readonly IRegistryClubRepository _registryClubRepository = registryClubRepository;
    private readonly IAthletRepository _athletRepository = athletRepository;
    private readonly IClubRepository _clubRepository = clubRepository;

    public async Task<MembershipDocument> SaveMembershipDocument(MembershipDocument document)
    {
        await ValidateAthletAndClubExistence(document);
        var found = await _registryClubRepository.GetByAthletIdFirstAsync(document.AthletID);
        if (found != null)
        {
            throw new ArgumentException("Спортсмен уже добавлен в спортивный клуб.");
        }

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await _membershipRepository.SaveAsync(document);
        await _registryClubRepository.SaveAsync(BuildRegistryClub(document));
        transaction.Complete();

        return document;
    }

    public async Task<ExclusionDocument> SaveExclusionDocument(ExclusionDocument document)
    {
        await ValidateAthletAndClubExistence(document);
        var found = await _registryClubRepository.GetByAthletIdFirstAsync(document.AthletID);
        if (found == null)
        {
            throw new ArgumentException("Спортсмен не принадлежит спортивному клубу.");
        }

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        await _exclusionRepository.SaveAsync(document);
        await _registryClubRepository.DeleteAsync(found);
        transaction.Complete();

        return document;
    }

    public Task<List<Athlet>> GetAthletsInClub(long clubId)
    {
        return _registryClubRepository.GetAthletsByClubIdAsync(clubId);
    }

    private async Task ValidateAthletAndClubExistence(RegistryDocument document)
    {
        var athletExists = await _athletRepository.ExistAthletByIdAsync(document.AthletID);
        if (!athletExists)
        {
            throw new ArgumentException($"Атлет с ID {document.AthletID} не найден в базе данных.");
        }

        var clubExists = await _clubRepository.ExistClubByIdAsync(document.ClubID);
        if (!clubExists)
        {
            throw new ArgumentException($"Клуб с ID {document.ClubID} не найден в базе данных.");
        }
    }

    private RegistryClub BuildRegistryClub(MembershipDocument document)
    {
        return new RegistryClub
        {
            AthletID = document.AthletID,
            ClubID = document.ClubID,
            CreateDate = document.Date
        };
    }
}
