using Api.DTOs.Company;
using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/company
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll(CancellationToken ct)
    {
        var companies = await _unitOfWork.Companies.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
    }

    // GET: api/company/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyDto>> GetById(int id, CancellationToken ct)
    {
        var company = await _unitOfWork.Companies.GetByIdAsync(id, ct);
        if (company is null) return NotFound();

        return Ok(_mapper.Map<CompanyDto>(company));
    }

    // POST: api/company
    [HttpPost]
    public async Task<ActionResult<CompanyDto>> Create([FromBody] CreateCompanyDto dto, CancellationToken ct)
    {
        var company = _mapper.Map<Company>(dto);

        // City debe ser asignada manualmente porque se ignora en AutoMapper
        var city = await _unitOfWork.Cities.GetByIdAsync(dto.CityId, ct);
        if (city is null) return BadRequest($"City with id {dto.CityId} not found.");
        company.City = city;

        await _unitOfWork.Companies.AddAsync(company, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        var result = _mapper.Map<CompanyDto>(company);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, result);
    }

    // PUT: api/company/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto dto, CancellationToken ct)
    {
        var existing = await _unitOfWork.Companies.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        // City debe actualizarse manualmente
        var city = await _unitOfWork.Cities.GetByIdAsync(dto.CityId, ct);
        if (city is null) return BadRequest($"City with id {dto.CityId} not found.");

        _mapper.Map(dto, existing);
        existing.City = city;

        await _unitOfWork.Companies.UpdateAsync(existing, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return NoContent();
    }

    // DELETE: api/company/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _unitOfWork.Companies.DeleteAsync(id, ct);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync(ct);
        return NoContent();
    }
}
