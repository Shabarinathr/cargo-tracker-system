using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CargoTracker.Data;
using CargoTracker.Models;

[ApiController]
[Route("api/[controller]")]
public class ContainersController : ControllerBase
{
    private readonly AppDbContext _context;
    public ContainersController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        => await _context.Containers.ToListAsync();
}
