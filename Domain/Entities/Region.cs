namespace Domain.Entities;

using Domain.ValueObjects;

public class Region
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!;
    // Relaciones
    public Country Country { get; set; } = null!;
}
