namespace Domain.ValueObjects;

public record UkNiu
{
    public int Value { get; }

    public UkNiu(int value)
    {
        if (value <= 0)
            throw new ArgumentException("UkNiu debe ser un valor positivo.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
