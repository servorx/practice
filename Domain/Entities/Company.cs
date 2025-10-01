namespace Domain.Entities;

using Domain.ValueObjects;

public class Company
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!;
    public UkNiu UkNiu { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public Email Email { get; set; } = null!;
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
