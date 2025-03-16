using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalespersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalespersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salesperson>>> GetSalespersons()
        {
            return await _context.Salespersons.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salesperson>> GetSalesperson(int id)
        {
            var salesperson = await _context.Salespersons.FindAsync(id);

            if (salesperson == null)
            {
                return NotFound();
            }

            return salesperson;
        }

        [HttpPost]
        public async Task<ActionResult<Salesperson>> CreateSalesperson(Salesperson salesperson)
        {
            // Check for duplicate name with same address
            if (await _context.Salespersons.AnyAsync(s =>
                s.FirstName.ToLower() == salesperson.FirstName.ToLower() &&
                s.LastName.ToLower() == salesperson.LastName.ToLower() &&
                s.Address == salesperson.Address))
            {
                return BadRequest($"A salesperson named '{salesperson.FirstName} {salesperson.LastName}' already exists at this address.");
            }

            _context.Salespersons.Add(salesperson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesperson), new { id = salesperson.Id }, salesperson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesperson(int id, Salesperson salesperson)
        {
            if (id != salesperson.Id)
            {
                return BadRequest("ID in route does not match ID in request body");
            }

            var existingSalesperson = await _context.Salespersons.FindAsync(id);
            if (existingSalesperson == null)
            {
                return NotFound();
            }

            // Check for duplicate name (case-insensitive) with same address
            // Only perform this check if name or address has changed
            bool nameChanged = salesperson.FirstName.ToLower() != existingSalesperson.FirstName.ToLower() ||
                              salesperson.LastName.ToLower() != existingSalesperson.LastName.ToLower();
            bool addressChanged = salesperson.Address != existingSalesperson.Address;
            bool phoneChanged = salesperson.Phone != existingSalesperson.Phone;

            // Check for address uniqueness constraint
            if ((nameChanged || addressChanged) &&
                await _context.Salespersons.AnyAsync(s =>
                    s.Id != id &&
                    s.FirstName.ToLower() == salesperson.FirstName.ToLower() &&
                    s.LastName.ToLower() == salesperson.LastName.ToLower() &&
                    s.Address == salesperson.Address))
            {
                return BadRequest($"A salesperson named '{salesperson.FirstName} {salesperson.LastName}' already exists at this address.");
            }
            
            // Check for phone uniqueness constraint
            if ((nameChanged || phoneChanged) &&
                await _context.Salespersons.AnyAsync(s =>
                    s.Id != id &&
                    s.FirstName.ToLower() == salesperson.FirstName.ToLower() &&
                    s.LastName.ToLower() == salesperson.LastName.ToLower() &&
                    s.Phone == salesperson.Phone))
            {
                return BadRequest($"A salesperson named '{salesperson.FirstName} {salesperson.LastName}' already exists with phone number '{salesperson.Phone}'.");
            }

            existingSalesperson.FirstName = salesperson.FirstName;
            existingSalesperson.LastName = salesperson.LastName;
            existingSalesperson.Address = salesperson.Address;
            existingSalesperson.Phone = salesperson.Phone;
            existingSalesperson.StartDate = salesperson.StartDate;
            existingSalesperson.TerminationDate = salesperson.TerminationDate;
            existingSalesperson.Manager = salesperson.Manager;

            _context.Entry(existingSalesperson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalespersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the detailed exception 
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                
                // Check for uniqueness constraint violation
                if (ex.InnerException != null && ex.InnerException.Message.Contains("IX_Salespersons_FirstName_LastName"))
                {
                    return BadRequest($"There's already a salesperson with the same name ('{salesperson.FirstName} {salesperson.LastName}') and either same address or phone. Please use different contact information.");
                }
                
                // Return a meaningful response to the client
                return BadRequest($"Could not update salesperson: {ex.Message}");
            }

            return NoContent();
        }

        private bool SalespersonExists(int id)
        {
            return _context.Salespersons.Any(e => e.Id == id);
        }
    }
}