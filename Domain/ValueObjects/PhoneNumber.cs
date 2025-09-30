namespace Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El teléfono no puede estar vacío.");

        if (value.Length < 7 || value.Length > 15)
            throw new ArgumentException("El teléfono debe tener entre 7 y 15 dígitos.");

        if (!value.All(char.IsDigit))
            throw new ArgumentException("El teléfono solo debe contener números.");

        Value = value;
    }

    public override string ToString() => Value;
}
