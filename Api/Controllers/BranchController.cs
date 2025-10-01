using Api.DTOs.Branch;
using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BranchesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/branches
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BranchDto>>> GetAll(CancellationToken ct)
    {
        var branches = await _unitOfWork.Branches.GetAllAsync(ct);
        return Ok(_mapper.Map<IEnumerable<BranchDto>>(branches));
    }

    // GET: api/branches/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BranchDto>> GetById(int id, CancellationToken ct)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(id, ct);
        if (branch is null) return NotFound();

        return Ok(_mapper.Map<BranchDto>(branch));
    }

    // POST: api/branches
    [HttpPost]
    public async Task<ActionResult<BranchDto>> Create([FromBody] CreateBranchDto dto, CancellationToken ct)
    {
        var branch = _mapper.Map<Branch>(dto);

        // Resolver relaciones manualmente
        branch.City = await _unitOfWork.Cities.GetByIdAsync(dto.CityId, ct) 
            ?? throw new ArgumentException($"City {dto.CityId} not found");

        branch.Company = await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId, ct) 
            ?? throw new ArgumentException($"Company {dto.CompanyId} not found");

        await _unitOfWork.Branches.AddAsync(branch, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        var result = _mapper.Map<BranchDto>(branch);
        return CreatedAtAction(nameof(GetById), new { id = branch.Id }, result);
    }

    // PUT: api/branches/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBranchDto dto, CancellationToken ct)
    {
        var existing = await _unitOfWork.Branches.GetByIdAsync(id, ct);
        if (existing is null) return NotFound();

        _mapper.Map(dto, existing);

        existing.City = await _unitOfWork.Cities.GetByIdAsync(dto.CityId, ct) 
            ?? throw new ArgumentException($"City {dto.CityId} not found");

        existing.Company = await _unitOfWork.Companies.GetByIdAsync(dto.CompanyId, ct) 
            ?? throw new ArgumentException($"Company {dto.CompanyId} not found");

        await _unitOfWork.Branches.UpdateAsync(existing, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return NoContent();
    }

    // DELETE: api/branches/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var deleted = await _unitOfWork.Branches.DeleteAsync(id, ct);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync(ct);
        return NoContent();
    }
}
