using SportClubApi.DataBase;
using SportClubApi.Interface;
using SportClubApi.Models.Registry;

namespace SportClubApi.Repositoory;

public class MembershipRepository(ApplicationContext context) : IMembershipRepository
{
    private readonly ApplicationContext _context = context;

    public async Task<MembershipDocument> SaveAsync(MembershipDocument document)
    {
        await _context.MembershipDocuments.AddAsync(document);
        await _context.SaveChangesAsync();
        return document;
    }

    public async Task DeleteAsync(MembershipDocument document) {
        _context.MembershipDocuments.Remove(document);
        await _context.SaveChangesAsync();
    }
}
