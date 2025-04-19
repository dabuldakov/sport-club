namespace SportClubApi.Controllers;

public static class ApiRoutes
{
    public const string Base = "api";
    public const string Initialize = $"{Base}/initialize";

    public static class Registry
    {
        public const string Membership = $"{Base}/registry/membership";
        public const string Exclusion = $"{Base}/registry/exclusion";
        
    }
}
