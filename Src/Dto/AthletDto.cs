using SportClubApi.Models.Registry;

namespace SportClubApi.Models;

public class AthletDto
{
    public long Id { get; set; }
    public required string Fio { get; set; }
    public required long SportTypeId { get; set; }
    public required int ExpirenceWorkDays { get; set; }
}
