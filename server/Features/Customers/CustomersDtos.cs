namespace server.Features.Customers;

public record CustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string Address,
    string Phone,
    DateTime StartDate
);

public record CreateCustomerDto(
    string FirstName,
    string LastName,
    string Address,
    string Phone,
    DateTime StartDate
);