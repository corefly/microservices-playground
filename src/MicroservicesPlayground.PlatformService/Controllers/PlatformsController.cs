using AutoMapper;
using MicroservicesPlayground.PlatformService.Data;
using MicroservicesPlayground.PlatformService.Dtos;
using MicroservicesPlayground.PlatformService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPlayground.PlatformService.Controllers;

[ApiController, Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platforms = _repository.GetAllPlatforms();

        return Ok(_mapper.Map<ICollection<PlatformReadDto>>(platforms));
    }

    [HttpGet, Route("{id:int}", Name = "GetPlatform")]
    public async Task<ActionResult<PlatformReadDto>> GetPlatform(int id)
    {
        var platform = await _repository.GetPlatform(id);

        if (platform != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platform = _mapper.Map<Platform>(platformCreateDto);

        await _repository.CreatePlatform(platform);
        await _repository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

        return CreatedAtRoute(nameof(GetPlatform), new { platformReadDto.Id }, platformReadDto);
    }
}
