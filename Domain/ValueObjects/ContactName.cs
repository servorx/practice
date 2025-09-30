namespace Domain.ValueObjects;

public record ContactName
{
    public string Value { get; }

    public ContactName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de contacto no puede estar vacío.");

        if (value.Length < 2)
            throw new ArgumentException("El nombre de contacto debe tener al menos 2 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
