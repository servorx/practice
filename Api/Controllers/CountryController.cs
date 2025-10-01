using Api.DTOs.Country;
using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll(CancellationToken ct)
    {
        var countries = await _unitOfWork.Countries.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<CountryDto>>(countries));
    }

    // GET: api/country/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CountryDto>> GetById(int id, CancellationToken ct)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id, ct);
        if (country is null) return NotFound();

        return Ok(_mapper.Map<CountryDto>(country));
    }

    // POST: api/country
    [HttpPost]
    public async Task<ActionResult<CountryDto>> Create([FromBody] CreateCountryDto dto, CancellationToken ct)
    {
        var country = _mapper.Map<Country>(dto);
        await _unitOfWork.Countries.AddAsync(country, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        var result = _mapper.Map<CountryDto>(country);
        return CreatedAtAction(nameof(GetById), new { id = country.Id }, result);
    }

    // PUT: api/country/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDto dto, CancellationToken ct)
    {
        var existing = await _unitOfWork.Countries.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        _mapper.Map(dto, existing);
        await _unitOfWork.Countries.UpdateAsync(existing, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return NoContent();
    }

    // DELETE: api/country/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _unitOfWork.Countries.DeleteAsync(id, ct);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync(ct);
        return NoContent();
    }
}
