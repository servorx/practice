namespace Domain.ValueObjects;

public record Address
{
    public string Value { get; }

    public Address(string value)
    {
        // estas son las validaciones que se van a aplicar
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La dirección no puede estar vacía.");
        else if (value.Length < 5)
            throw new ArgumentException("La dirección debe tener al menos 5 caracteres.");
        else if (value.Length > 80)
            throw new ArgumentException("La dirección no puede exceder los 80 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
