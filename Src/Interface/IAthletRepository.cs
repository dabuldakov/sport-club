namespace SportClubApi;

public interface IAthletRepository
{
    public Task<bool> ExistAthletByIdAsync(long clubId);
}
