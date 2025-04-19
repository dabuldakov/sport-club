using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SportClubApi.Dto;
using SportClubApi.Mapper;
using SportClubApi.Service;

namespace SportClubApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RegistryClubController(RegistryClubService registryClubService, RegistryDocumentMapper registryDocumentMapper) : ControllerBase
{
    private readonly RegistryClubService service = registryClubService;
    private readonly RegistryDocumentMapper mapper = registryDocumentMapper;

    [HttpPost]
    public ActionResult<long> SaveMembershipDocument(MembershipDocumentDto dto)
    {
        var request = mapper.ToDomainMembership(dto);
        var result = mapper.ToDtoMembership(service.SaveMembershipDocument(request));
        return Ok(result.Id);
    }

        [HttpPost]
    public ActionResult<long> SaveExclusionDocument(MembershipDocumentDto dto)
    {
        var request = mapper.ToDomainMembership(dto);
        var result = mapper.ToDtoMembership(service.SaveMembershipDocument(request));
        return Ok(result.Id);
    }
}
