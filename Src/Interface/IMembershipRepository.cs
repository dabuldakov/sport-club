using SportClubApi.Models.Registry;

namespace SportClubApi.Interface;

public interface IMembershipRepository
{
    public MembershipDocument Save(MembershipDocument document);
    public void Delete(MembershipDocument document);
}
