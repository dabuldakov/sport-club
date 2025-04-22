using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class ExcclusionRepository(ApplicationContext context) : IExclusionRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<ExclusionDocument> SaveAsync(ExclusionDocument document)
    {
        await _context.ExclusionDocuments.AddAsync(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task DeleteAsync(ExclusionDocument document) {
        _context.ExclusionDocuments.Remove(document);
        await _context.SaveChangesAsync();
    }

}
