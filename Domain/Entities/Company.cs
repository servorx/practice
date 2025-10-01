namespace Domain.Entities;

using Domain.ValueObjects;

public class Company
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!; // esto es string
    public UkNiu UkNiu { get; set; } = null!; // esto es int
    public Address Address { get; set; } = null!; // esto es string
    public Email Email { get; set; } = null!; // esto es string
    // Relaciones
    public City City { get; set; } = null!;
    // establecer constructor
    public Company() { }
    public Company(EntityName name, UkNiu ukNiu, Address address, Email email, City city)
    {
        Name = name;
        UkNiu = ukNiu;
        Address = address;
        Email = email;
        City = city;
    }
}
