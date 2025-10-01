namespace Domain.ValueObjects;

public record EntityNumber
{
    public int Value { get; }

    public EntityNumber(int value)
    {
        if (value < 0)
            throw new ArgumentException("El número no puede ser negativo.");

        Value = value;
    }
    // el override de ToString es necesario para que el ValueObject se pueda utilizar en el DTO 
    public override string ToString() => Value.ToString();
}