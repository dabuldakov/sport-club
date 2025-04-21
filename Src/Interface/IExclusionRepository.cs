using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IExclusionRepository
{
    public ExclusionDocument Save(ExclusionDocument document);
    public void Delete(ExclusionDocument document);
}
