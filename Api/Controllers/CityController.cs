using Api.DTOs.City;
using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CitiesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/cities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDto>>> GetAll(CancellationToken ct)
    {
        var cities = await _unitOfWork.Cities.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<CityDto>>(cities));
    }

    // GET: api/cities/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CityDto>> GetById(int id, CancellationToken ct)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id, ct);
        if (city is null) return NotFound();

        return Ok(_mapper.Map<CityDto>(city));
    }

    // POST: api/cities
    [HttpPost]
    public async Task<ActionResult<CityDto>> Create([FromBody] CreateCityDto dto, CancellationToken ct)
    {
        var city = _mapper.Map<City>(dto);

        // Resolver relación con Region
        city.Region = await _unitOfWork.Regions.GetByIdAsync(dto.RegionId, ct)
            ?? throw new ArgumentException($"Region {dto.RegionId} not found");

        await _unitOfWork.Cities.AddAsync(city, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        var result = _mapper.Map<CityDto>(city);
        return CreatedAtAction(nameof(GetById), new { id = city.Id }, result);
    }

    // PUT: api/cities/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCityDto dto, CancellationToken ct)
    {
        var existing = await _unitOfWork.Cities.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        _mapper.Map(dto, existing);

        existing.Region = await _unitOfWork.Regions.GetByIdAsync(dto.RegionId, ct)
            ?? throw new ArgumentException($"Region {dto.RegionId} not found");

        await _unitOfWork.Cities.UpdateAsync(existing, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return NoContent();
    }

    // DELETE: api/cities/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _unitOfWork.Cities.DeleteAsync(id, ct);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync(ct);
        return NoContent();
    }
}
