namespace Domain.Entities;

using Domain.ValueObjects;

public class Region
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!; // esto es string
    // Relaciones
    public Country Country { get; set; } = null!;
    // establecer constructor
    public  Region() { }
    public Region(EntityName name, Country country)
    {
        Name = name;
        Country = country;
    }
}
