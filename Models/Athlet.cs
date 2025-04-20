using SportClubApi.Models.Registry;

namespace SportClubApi.Models;

public class Athlet
{
    public long ID { get; set; }
    public required string Fio { get; set; }
    public long SportTypeID { get; set; }
    public int ExpirenceWorkDays { get; set; }
    public ICollection<RegistryClub> RegistryClubs { get; set; } = [];
}
