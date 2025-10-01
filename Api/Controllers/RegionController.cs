using Api.DTOs.Region;
using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegionsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/regions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionDto>>> GetAll(CancellationToken ct)
    {
        var regions = await _unitOfWork.Regions.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));
    }

    // GET: api/regions/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RegionDto>> GetById(int id, CancellationToken ct)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(id, ct);
        if (region is null) return NotFound();

        return Ok(_mapper.Map<RegionDto>(region));
    }

    // POST: api/regions
    [HttpPost]
    public async Task<ActionResult<RegionDto>> Create([FromBody] CreateRegionDto dto, CancellationToken ct)
    {
        var region = _mapper.Map<Region>(dto);

        // Resolver relación con Country
        region.Country = await _unitOfWork.Countries.GetByIdAsync(dto.CountryId, ct)
            ?? throw new ArgumentException($"Country {dto.CountryId} not found");

        await _unitOfWork.Regions.AddAsync(region, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        var result = _mapper.Map<RegionDto>(region);
        return CreatedAtAction(nameof(GetById), new { id = region.Id }, result);
    }

    // PUT: api/regions/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRegionDto dto, CancellationToken ct)
    {
        var existing = await _unitOfWork.Regions.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        _mapper.Map(dto, existing);

        existing.Country = await _unitOfWork.Countries.GetByIdAsync(dto.CountryId, ct)
            ?? throw new ArgumentException($"Country {dto.CountryId} not found");

        await _unitOfWork.Regions.UpdateAsync(existing, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return NoContent();
    }

    // DELETE: api/regions/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _unitOfWork.Regions.DeleteAsync(id, ct);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync(ct);
        return NoContent();
    }
}
