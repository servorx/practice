namespace Domain.Entities;

using Domain.ValueObjects;

public class Country
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!;
    // establecer constructores
    public Country() { }
    public Country(EntityName name)
    {
        Name = name;
    }
}
