using SportClubApi.Models;

namespace SportClubApi.DataBase;

public class DbInitializer(ApplicationContext applicationContext)
{
    private readonly ApplicationContext context = applicationContext;
    public void Initialize()
    {
        var clubs = new[]
        {
            new Club { Name = "Club A", Description = "Description for Club A", SportTypeID = 1, MaxAthletes = 35 },
            new Club { Name = "Club B", Description = "Description for Club B", SportTypeID = 2, MaxAthletes = 100 }
        };

        var athlets = new[]
        {
            new Athlet { Fio = "Athlet One", ExpirenceWorkDays = 5, SportTypeID = 1 },
            new Athlet { Fio = "Athlet Two", ExpirenceWorkDays = 3, SportTypeID = 2 }
        };

        var sportTypes = new[]
        {
            new SportType { Name = "Football" },
            new SportType { Name = "Socket" }
        };

        context.SportTypes.AddRange(sportTypes);
        context.Clubs.AddRange(clubs);
        context.Athlets.AddRange(athlets);


        context.SaveChanges();
    }
}
