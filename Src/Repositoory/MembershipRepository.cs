using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class MembershipRepository(ApplicationContext context) : IMembershipRepository
{
    private readonly ApplicationContext _context = context;

    public MembershipDocument Save(MembershipDocument document)
    {
        _context.Set<MembershipDocument>().Add(document);
        _context.SaveChanges();
        return document;
    }

    public void Delete(MembershipDocument document) {
        _context.Set<MembershipDocument>().Remove(document);
    }
}
