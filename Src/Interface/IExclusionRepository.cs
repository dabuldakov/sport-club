using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IExclusionRepository
{
    public Task<ExclusionDocument> SaveAsync(ExclusionDocument document);
    public Task DeleteAsync(ExclusionDocument document);
}
