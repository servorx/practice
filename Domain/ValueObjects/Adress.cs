namespace Domain.ValueObjects;

public record Address
{
    public string Value { get; }

    public Address(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La dirección no puede estar vacía.");

        if (value.Length < 5)
            throw new ArgumentException("La dirección debe tener al menos 5 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
