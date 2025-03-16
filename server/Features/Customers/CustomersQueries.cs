using server.Common.Interfaces;
using server.Models;

namespace server.Features.Customers;

public class GetCustomersQuery(IRepository<Customer> repository)
{
    private readonly IRepository<Customer> _repository = repository;

    public async Task<IEnumerable<CustomerDto>> ExecuteAsync()
    {
        var customers = await _repository.GetAllAsync();

        return customers.Select(c => new CustomerDto(
            c.Id,
            c.FirstName,
            c.LastName,
            c.Address,
            c.Phone,
            c.StartDate
        ));
    }
}

public class GetCustomerByIdQuery(IRepository<Customer> repository)
{
    private readonly IRepository<Customer> _repository = repository;

    public async Task<CustomerDto?> ExecuteAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return null;

        return new CustomerDto(
            customer.Id,
            customer.FirstName,
            customer.LastName,
            customer.Address,
            customer.Phone,
            customer.StartDate
        );
    }
}