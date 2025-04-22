using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;

namespace SportClubApi.Repositoory;

public class AthletRepository(ApplicationContext context) : IAthletRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<bool> ExistAthletByIdAsync(long athletId)
    {
        return await _context.Athlets.AnyAsync(athlet => athlet.ID == athletId);
    }
}
