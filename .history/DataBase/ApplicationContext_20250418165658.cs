using Microsoft.EntityFrameworkCore;
using SportClubApi.Models;
using SportClubApi.Models.Regisrty;
using SportClubApi.Models.Registry;

namespace SportClubApi.DataBase;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Club> Clubs { get; set; } = null!;
    public DbSet<SportType> Types { get; set; } = null!;
    public DbSet<Athlet> Athlets { get; set; } = null!;
    public DbSet<ExclusionDocument> ExclusionDocuments { get; set; } = null!;
    public DbSet<MembershipDocument> MembershipDocuments { get; set; } = null!;
    public DbSet<RegistryClub> RegistryClubs { get; set; } = null!;

}
