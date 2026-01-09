using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CargoTracker.Data;
using CargoTracker.Models;

namespace CargoTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VesselsController : ControllerBase
{
    private readonly AppDbContext _context;

    public VesselsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/vessels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vessel>>> GetVessels()
    {
        var vessels = await _context.Vessels.ToListAsync();
        return Ok(vessels);
    }

    // GET: api/vessels/IMO9125050
    [HttpGet("{imo}")]
    public async Task<ActionResult<Vessel>> GetVessel(string imo)
    {
        var vessel = await _context.Vessels.FirstOrDefaultAsync(v => v.IMO == imo);
        
        if (vessel == null)
            return NotFound($"Vessel with IMO {imo} not found");

        return Ok(vessel);
    }

    // POST: api/vessels
    [HttpPost]
    public async Task<ActionResult<Vessel>> CreateVessel(CreateVesselDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var vessel = new Vessel
        {
            IMO = dto.IMO,
            Name = dto.Name,
            CapacityTEU = dto.CapacityTEU,
            CurrentPort = dto.CurrentPort,
            Status = dto.Status
        };

        _context.Vessels.Add(vessel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVessel), 
            new { imo = vessel.IMO }, vessel);
    }
}
