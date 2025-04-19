using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SportClubApi.DataBase;
using SportClubApi.Dto;
using SportClubApi.Mapper;
using SportClubApi.Service;

namespace SportClubApi.Controllers;

[ApiController]
public class RegistryClubController(
    RegistryClubService registryClubService,
    RegistryDocumentMapper registryDocumentMapper,
    DbInitializer dbInitializer) : ControllerBase
{
    private readonly RegistryClubService service = registryClubService;
    private readonly RegistryDocumentMapper mapper = registryDocumentMapper;
    private readonly DbInitializer initializer = dbInitializer;

    [HttpPost]
    [Route(ApiRoutes.Registry.Membership)]
    public ActionResult<long> SaveMembershipDocument(MembershipDocumentDto dto)
    {
        var request = mapper.ToDomainMembership(dto);
        var result = mapper.ToDtoMembership(service.SaveMembershipDocument(request));
        return Ok(result.Id);
    }

    [HttpPost]
    [Route(ApiRoutes.Registry.Exclusion)]
    public ActionResult<long> SaveExclusionDocument(ExclusionDocumentDto dto)
    {
        var request = mapper.ToDomainExclusion(dto);
        var result = mapper.ToDtoExclusion(service.SaveExclusionDocument(request));
        return Ok(result.Id);
    }

    [HttpGet]
    [Route(ApiRoutes.Initialize)]
    public ActionResult InitializeDb()
    {
        initializer.Initialize();
        return Ok();
    }
}
