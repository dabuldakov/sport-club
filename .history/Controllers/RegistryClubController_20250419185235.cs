using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SportClubApi.DataBase;
using SportClubApi.Dto;
using SportClubApi.Mapper;
using SportClubApi.Models;
using SportClubApi.Service;

namespace SportClubApi.Controllers;

[ApiController]
public class RegistryClubController(
    RegistryClubService registryClubService,
    RegistryDocumentMapper registryDocumentMapper,
    AthletMapper athletMapper,
    DbInitializer dbInitializer) : ControllerBase
{
    private readonly RegistryClubService service = registryClubService;
    private readonly RegistryDocumentMapper _registryMapper = registryDocumentMapper;
    private readonly AthletMapper _athletMapper = athletMapper;
    private readonly DbInitializer initializer = dbInitializer;

    [HttpPost]
    [Route(ApiRoutes.Registry.Membership)]
    public ActionResult<long> SaveMembershipDocument(MembershipDocumentDto dto)
    {
        var request = _registryMapper.ToDomainMembership(dto);
        var result = _registryMapper.ToDtoMembership(service.SaveMembershipDocument(request));
        return Ok(result.Id);
    }

    [HttpPost]
    [Route(ApiRoutes.Registry.Exclusion)]
    public ActionResult<long> SaveExclusionDocument(ExclusionDocumentDto dto)
    {
        var request = _registryMapper.ToDomainExclusion(dto);
        var result = _registryMapper.ToDtoExclusion(service.SaveExclusionDocument(request));
        return Ok(result.Id);
    }

    [HttpGet]
    [Route(ApiRoutes.Registry.Club + "{clubId}")]
    public async Task<ActionResult<List<AthletDto>>> GetAthletsByClubId(long clubId)
    {
        var athlets = await service.GetAthletsInClub(clubId);
        if (athlets == null || !athlets.Any())
        {
            return NotFound();
        }

        return Ok(athlets.Select(_athletMapper.ToDto));
    }

    [HttpGet]
    [Route(ApiRoutes.Initialize)]
    public ActionResult InitializeDb()
    {
        initializer.Initialize();
        return Ok();
    }
}
