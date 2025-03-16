using Microsoft.AspNetCore.Mvc;

namespace server.Features.Salespersons;

[ApiController]
[Route("api/[controller]")]
public class SalespersonsController : ControllerBase
{
    private readonly GetSalespersonsQuery _getSalespersonsQuery;
    private readonly GetSalespersonByIdQuery _getSalespersonByIdQuery;
    private readonly CreateSalespersonCommand _createSalespersonCommand;
    private readonly UpdateSalespersonCommand _updateSalespersonCommand;

    public SalespersonsController(
        GetSalespersonsQuery getSalespersonsQuery,
        GetSalespersonByIdQuery getSalespersonByIdQuery,
        CreateSalespersonCommand createSalespersonCommand,
        UpdateSalespersonCommand updateSalespersonCommand)
    {
        _getSalespersonsQuery = getSalespersonsQuery;
        _getSalespersonByIdQuery = getSalespersonByIdQuery;
        _createSalespersonCommand = createSalespersonCommand;
        _updateSalespersonCommand = updateSalespersonCommand;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalespersonDto>>> GetSalespersons()
    {
        var salespersons = await _getSalespersonsQuery.ExecuteAsync();
        return Ok(salespersons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalespersonDto>> GetSalesperson(int id)
    {
        var salesperson = await _getSalespersonByIdQuery.ExecuteAsync(id);

        if (salesperson == null)
        {
            return NotFound();
        }

        return salesperson;
    }

    [HttpPost]
    public async Task<ActionResult<SalespersonDto>> CreateSalesperson(CreateSalespersonDto salespersonDto)
    {
        var result = await _createSalespersonCommand.ExecuteAsync(salespersonDto);

        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return CreatedAtAction(nameof(GetSalesperson), new { id = result.Salesperson!.Id }, result.Salesperson);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSalesperson(int id, SalespersonDto salespersonDto)
    {
        var result = await _updateSalespersonCommand.ExecuteAsync(id, salespersonDto);

        if (!result.Success)
        {
            return result.ErrorMessage switch
            {
                "Salesperson not found" => NotFound(),
                _ => BadRequest(result.ErrorMessage)
            };
        }

        return NoContent();
    }
}