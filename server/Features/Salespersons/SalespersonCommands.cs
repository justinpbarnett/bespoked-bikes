using Microsoft.EntityFrameworkCore;
using server.Common.Interfaces;
using server.Infrastructure.Data;
using server.Models;

namespace server.Features.Salespersons;

public class UpdateSalespersonCommand
{
    private readonly IRepository<Salesperson> _repository;
    private readonly ApplicationDbContext _context;

    public UpdateSalespersonCommand(IRepository<Salesperson> repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<(bool Success, string? ErrorMessage)> ExecuteAsync(int id, SalespersonDto dto)
    {
        if (id != dto.Id)
        {
            return (false, "ID mismatch between route and payload");
        }

        var existingSalesperson = await _repository.GetByIdAsync(id);
        if (existingSalesperson == null)
        {
            return (false, "Salesperson not found");
        }

        // Check for duplicate name (case-insensitive) with same address
        // Only perform this check if name or address has changed
        bool nameChanged = dto.FirstName.ToLower() != existingSalesperson.FirstName.ToLower() ||
                          dto.LastName.ToLower() != existingSalesperson.LastName.ToLower();
        bool addressChanged = dto.Address != existingSalesperson.Address;
        bool phoneChanged = dto.Phone != existingSalesperson.Phone;

        // Check for address uniqueness constraint
        if ((nameChanged || addressChanged) &&
            await _context.Salespersons.AnyAsync(s =>
                s.Id != id &&
                s.FirstName.ToLower() == dto.FirstName.ToLower() &&
                s.LastName.ToLower() == dto.LastName.ToLower() &&
                s.Address == dto.Address))
        {
            return (false, $"A salesperson named '{dto.FirstName} {dto.LastName}' already exists at this address.");
        }

        // Check for phone uniqueness constraint
        if ((nameChanged || phoneChanged) &&
            await _context.Salespersons.AnyAsync(s =>
                s.Id != id &&
                s.FirstName.ToLower() == dto.FirstName.ToLower() &&
                s.LastName.ToLower() == dto.LastName.ToLower() &&
                s.Phone == dto.Phone))
        {
            return (false, $"A salesperson named '{dto.FirstName} {dto.LastName}' already exists with phone number '{dto.Phone}'.");
        }

        existingSalesperson.FirstName = dto.FirstName;
        existingSalesperson.LastName = dto.LastName;
        existingSalesperson.Address = dto.Address;
        existingSalesperson.Phone = dto.Phone;
        existingSalesperson.StartDate = dto.StartDate;
        existingSalesperson.TerminationDate = dto.TerminationDate;
        existingSalesperson.Manager = dto.Manager;

        try
        {
            await _repository.UpdateAsync(existingSalesperson);
            return (true, null);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await SalespersonExistsAsync(id))
            {
                return (false, "Salesperson not found");
            }
            throw;
        }
        catch (DbUpdateException ex)
        {
            // Check for uniqueness constraint violation
            if (ex.InnerException != null && ex.InnerException.Message.Contains("IX_Salespersons_FirstName_LastName"))
            {
                return (false, $"There's already a salesperson with the same name ('{dto.FirstName} {dto.LastName}') and either same address or phone. Please use different contact information.");
            }

            // Return a meaningful response to the client
            return (false, $"Could not update salesperson: {ex.Message}");
        }
    }

    private async Task<bool> SalespersonExistsAsync(int id)
    {
        return await _context.Salespersons.AnyAsync(e => e.Id == id);
    }
}

public class CreateSalespersonCommand
{
    private readonly IRepository<Salesperson> _repository;
    private readonly ApplicationDbContext _context;

    public CreateSalespersonCommand(IRepository<Salesperson> repository, ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<(bool Success, SalespersonDto? Salesperson, string? ErrorMessage)> ExecuteAsync(CreateSalespersonDto dto)
    {
        // Check for duplicate name with same address
        if (await _context.Salespersons.AnyAsync(s =>
            s.FirstName.ToLower() == dto.FirstName.ToLower() &&
            s.LastName.ToLower() == dto.LastName.ToLower() &&
            s.Address == dto.Address))
        {
            return (false, null, $"A salesperson named '{dto.FirstName} {dto.LastName}' already exists at this address.");
        }

        var salesperson = new Salesperson
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
            Phone = dto.Phone,
            StartDate = dto.StartDate,
            TerminationDate = dto.TerminationDate,
            Manager = dto.Manager
        };

        await _repository.AddAsync(salesperson);

        return (true, new SalespersonDto(
            salesperson.Id,
            salesperson.FirstName,
            salesperson.LastName,
            salesperson.Address,
            salesperson.Phone,
            salesperson.StartDate,
            salesperson.TerminationDate,
            salesperson.Manager
        ), null);
    }
}