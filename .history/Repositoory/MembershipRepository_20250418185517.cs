using SportClubApi.DataBase;
using SportClubApi.Models.Regisrty;

namespace SportClubApi.Repositoory;

public class MembershipRepository(ApplicationContext context)
{
    private readonly ApplicationContext _context = context;

    public MembershipDocument Save(MembershipDocument document)
    {
        _context.Set<MembershipDocument>().Add(document);
        _context.SaveChanges();
        return document;
    }

}
