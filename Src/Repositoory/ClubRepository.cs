using Microsoft.EntityFrameworkCore;
using SportClubApi.DataBase;
using SportClubApi.Interface;

namespace SportClubApi;

public class ClubRepository(ApplicationContext context) : IClubRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<bool> ExistClubByIdAsync(long clubId)
    {
        return await _context.Clubs.AnyAsync(club => club.ID == clubId);
    }
}
