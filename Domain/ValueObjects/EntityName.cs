namespace Domain.ValueObjects;

public record EntityName
{
    public string Value { get; }

    public EntityName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío.");
        else if (value.Length > 120)
            throw new ArgumentException("El nombre no puede exceder los 120 caracteres.");
        else if (value.Length < 2)
            throw new ArgumentException("El nombre debe tener al menos 2 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
