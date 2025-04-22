using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IMembershipRepository
{
    public Task<MembershipDocument> SaveAsync(MembershipDocument document);
    public Task DeleteAsync(MembershipDocument document);
}
