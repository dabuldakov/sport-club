
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IRegistryClubRepository
{
    
    public Task SaveAsync(RegistryClub registryClub);
    public Task DeleteAsync(RegistryClub registryClub);

    public Task<RegistryClub?> GetByAthletIdFirstAsync(long athletId);
    public Task<List<Athlet>> GetAthletsByClubIdAsync(long clubId);
    
}