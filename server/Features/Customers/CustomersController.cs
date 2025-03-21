using Microsoft.AspNetCore.Mvc;

namespace server.Features.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(
    GetCustomersQuery getCustomersQuery,
    GetCustomerByIdQuery getCustomerByIdQuery,
    CreateCustomerCommand createCustomerCommand) : ControllerBase
{
    private readonly GetCustomersQuery _getCustomersQuery = getCustomersQuery;
    private readonly GetCustomerByIdQuery _getCustomerByIdQuery = getCustomerByIdQuery;
    private readonly CreateCustomerCommand _createCustomerCommand = createCustomerCommand;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _getCustomersQuery.ExecuteAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _getCustomerByIdQuery.ExecuteAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto customerDto)
    {
        var customer = await _createCustomerCommand.ExecuteAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }
}