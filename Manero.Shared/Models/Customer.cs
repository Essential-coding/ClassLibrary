using Manero.Shared.Interfaces;

namespace Manero.Shared.Models;

public class Customer : ICustomer
{

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    // Genererar automatiskt ett unikt nummer
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
