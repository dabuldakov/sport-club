using SportClubApi.DataBase;
using SportClubApi.Models.Regisrty;

namespace SportClubApi.Repositoory;

public class ExcclusionRepository(ApplicationContext context)
{
    private readonly ApplicationContext _context = context;

    public ExclusionDocument Save(ExclusionDocument document)
    {
        _context.Set<ExclusionDocument>().Add(document);
        _context.SaveChanges();
        return document;
    }

}
