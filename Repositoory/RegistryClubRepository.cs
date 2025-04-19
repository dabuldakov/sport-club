using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;
using SportClubApi.Models;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class RegistryClubRepository(ApplicationContext context)
{
    private readonly ApplicationContext _context = context;

    public void Save(RegistryClub registryClub)
    {
        _context.RegistryClubs.Add(registryClub);
        _context.SaveChanges();
    }

    public void Delete(RegistryClub registryClub)
    {
        _context.RegistryClubs.Remove(registryClub);
        _context.SaveChanges();
    }

    public RegistryClub? Find(RegClubPk pk)
    {
        return _context.RegistryClubs.Find(pk.ClubId, pk.AthletId);
    }

    public async Task<List<Athlet>> GetAthletsByClubIdAsync(long clubId)
    {
        return await _context.RegistryClubs
            .Where(registry => registry.ClubID == clubId)
            .Select(registry => registry.Athlet)
            .ToListAsync();
    }
}
