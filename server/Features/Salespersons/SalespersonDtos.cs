namespace server.Features.Salespersons;

public record SalespersonDto(
    int Id,
    string FirstName,
    string LastName,
    string Address,
    string Phone,
    DateTime StartDate,
    DateTime? TerminationDate,
    string? Manager
);

public record CreateSalespersonDto(
    string FirstName,
    string LastName,
    string Address,
    string Phone,
    DateTime StartDate,
    DateTime? TerminationDate,
    string? Manager
);