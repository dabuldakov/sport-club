using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class RegistryClubRepository(ApplicationContext context) : IRegistryClubRepository
{
    private readonly ApplicationContext _context = context;

    public async Task SaveAsync(RegistryClub registryClub)
    {
        await _context.RegistryClubs.AddAsync(registryClub);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RegistryClub registryClub)
    {
        _context.RegistryClubs.Remove(registryClub);
        await _context.SaveChangesAsync();
    }

    
    public async Task<RegistryClub?> GetByAthletIdFirstAsync(long athletId)
    {
        return await _context.RegistryClubs
            .Where(registry => registry.AthletID == athletId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Athlet>> GetAthletsByClubIdAsync(long clubId)
    {
        return await _context.RegistryClubs
            .Where(registry => registry.ClubID == clubId)
            .Select(registry => registry.Athlet)
            .ToListAsync();
    }
}
