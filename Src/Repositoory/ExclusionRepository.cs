using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class ExcclusionRepository(ApplicationContext context) : IExclusionRepository
{
    private readonly ApplicationContext _context = context;

    public ExclusionDocument Save(ExclusionDocument document)
    {
        _context.ExclusionDocuments.Add(document);
        _context.SaveChanges();
        return document;
    }

    public void Delete(ExclusionDocument document) {
        _context.ExclusionDocuments.Remove(document);
        _context.SaveChanges();
    }

}
