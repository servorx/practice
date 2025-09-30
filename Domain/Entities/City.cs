namespace Domain.Entities;

using Domain.ValueObjects;

public class City
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!;

    // Relaciones
    public Region Region { get; set; } = null!;
}
