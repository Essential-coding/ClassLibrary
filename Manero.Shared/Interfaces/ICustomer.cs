﻿namespace Manero.Shared.Interfaces;

public interface ICustomer
{

    public string FirstName { get; set; }
    public string LastName { get; set; } 

    public string Address { get; set; } 

    public string City { get; set; } 

    public string Country { get; set; }

    // Genererar automatiskt ett unikt nummer
    public Guid Id { get; set; } 
    public string Email { get; set; } 
    public string PhoneNumber { get; set; }

}
