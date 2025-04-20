using SportClubApi.Models.Registry;

namespace SportClubApi.Models;

public class AthletDto
{
    public long Id { get; set; }
    public required string Fio { get; set; }
    public long SportTypeId { get; set; }
    public int ExpirenceWorkDays { get; set; }
}
