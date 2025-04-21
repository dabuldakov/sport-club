
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IRegistryClubRepository
{
    
    public void Save(RegistryClub registryClub);
    public void Delete(RegistryClub registryClub);

    public Task<RegistryClub?> GetByAthletIdFirstAsync(long athletId);
    public Task<List<Athlet>> GetAthletsByClubIdAsync(long clubId);
    
}