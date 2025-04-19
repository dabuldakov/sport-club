using Microsoft.EntityFrameworkCore;

namespace SportClubApi.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    public DbSet<Club> Clubs {get; set;} = null!;
    public DbSet<SportType> Types {get; set;} = null!;

    public DbSet<Athlet> Athlets {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>()
            .HasOne(s => s.SportType)
            .WithMany()
            .HasForeignKey(s => s.SportTypeId);
    }
}
