namespace Domain.ValueObjects;

public record UkNiu
{
    public int Value { get; }

    public UkNiu(int value)
    {
        // validar que sea mayor a 0
        if (value <= 0)
            throw new ArgumentException("UkNiu debe ser un valor positivo y mayor que cero.");
        else if (value > 999999)
            throw new ArgumentException("UkNiu no puede exceder los 6 caracteres.");
        
        Value = value;
    }

    public override string ToString() => Value.ToString();
}
