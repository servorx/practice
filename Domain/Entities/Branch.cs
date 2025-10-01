namespace Domain.Entities;

using Domain.ValueObjects;

public class Branch
{
    public int Id { get; set; }
    public EntityNumber NumberCommercial { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public ContactName ContactName { get; set; } = null!;
    public PhoneNumber Phone { get; set; } = null!;
    // estos son las relaciones
    public City City { get; set; } = null!;
    public Company Company { get; set; } = null!;
    // definir constructores 
    public Branch() { }
    public Branch(EntityNumber numberCommercial, Address address, Email email, ContactName contactName, PhoneNumber phone, City city, Company company)
    {
        NumberCommercial = numberCommercial;
        Address = address;
        Email = email;
        ContactName = contactName;
        Phone = phone;
        City = city;
        Company = company;
    }
}
