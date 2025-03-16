using server.Common.Interfaces;
using server.Models;

namespace server.Features.Customers;

public class CreateCustomerCommand
{
    private readonly IRepository<Customer> _repository;

    public CreateCustomerCommand(IRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDto> ExecuteAsync(CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Address = dto.Address,
            Phone = dto.Phone,
            StartDate = dto.StartDate
        };

        await _repository.AddAsync(customer);

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