using Microsoft.EntityFrameworkCore;

namespace SportClubApi.Models;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Club> Clubs {get; set;} = null!;
    public DbSet<SportType> Types {get; set;} = null!;

    public DbSet<Athlet> Athlets {get; set;} = null!;

}
