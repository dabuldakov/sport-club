namespace SportClubApi.Models;

public class Athlet
{
    
    public long Id;
    public required string Fio {get; set;}
    public long SportTypeId {get; set;}
    public int ExpirenceWorkDays {get; set;}

    public SportType SportType { get; set; } = null!;
}
