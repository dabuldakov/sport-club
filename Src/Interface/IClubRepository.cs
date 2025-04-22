using System.Threading.Tasks;

namespace SportClubApi.Interface;

public interface IClubRepository
{
    public Task<bool> ExistClubByIdAsync(long clubId);
}