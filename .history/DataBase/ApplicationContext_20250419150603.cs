using Microsoft.EntityFrameworkCore;
using SportClubApi.Models;
using SportClubApi.Models.Regisrty;
using SportClubApi.Models.Registry;

namespace SportClubApi.DataBase;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Club> Clubs { get; set; } = null!;
    public DbSet<SportType> SportTypes { get; set; } = null!;
    public DbSet<Athlet> Athlets { get; set; } = null!;
    public DbSet<ExclusionDocument> ExclusionDocuments { get; set; } = null!;
    public DbSet<MembershipDocument> MembershipDocuments { get; set; } = null!;
    public DbSet<RegistryClub> RegistryClubs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistryClub>()
            .HasKey(r => new RegClubPk(r.ClubId, r.AthletId));

        modelBuilder.Entity<RegistryClub>()
            .HasOne(r => r.Club)
            .WithMany() // Здесь также можете указать коллекцию в Club, если она есть
            .HasForeignKey(r => r.ClubId);

        modelBuilder.Entity<RegistryClub>()
            .HasOne(r => r.Athlet)
            .WithMany() // Здесь также можете указать коллекцию в Athlet, если она есть
            .HasForeignKey(r => r.AthletId);
    }
}
