using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models;

namespace SportClubApi.Service;

public class ClubService(ApplicationContext context) : IClubService
{
    private readonly ApplicationContext _context = context;

    public void Create(Club club) {
            _context.Clubs.Add(club);
            _context.SaveChangesAsync();
    }
}
