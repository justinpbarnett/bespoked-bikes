using server.Common.Interfaces;
using server.Models;

namespace server.Features.Salespersons;

public class GetSalespersonByIdQuery(IRepository<Salesperson> repository)
{
    private readonly IRepository<Salesperson> _repository = repository;

    public async Task<SalespersonDto?> ExecuteAsync(int id)
    {
        var salesperson = await _repository.GetByIdAsync(id);

        if (salesperson == null)
            return null;

        return new SalespersonDto(
            salesperson.Id,
            salesperson.FirstName,
            salesperson.LastName,
            salesperson.Address,
            salesperson.Phone,
            salesperson.StartDate,
            salesperson.TerminationDate,
            salesperson.Manager
        );
    }
}

public class GetSalespersonsQuery(IRepository<Salesperson> repository)
{
    private readonly IRepository<Salesperson> _repository = repository;

    public async Task<IEnumerable<SalespersonDto>> ExecuteAsync()
    {
        var salespersons = await _repository.GetAllAsync();

        return salespersons.Select(s => new SalespersonDto(
            s.Id,
            s.FirstName,
            s.LastName,
            s.Address,
            s.Phone,
            s.StartDate,
            s.TerminationDate,
            s.Manager
        ));
    }
}