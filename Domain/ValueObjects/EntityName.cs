namespace Domain.ValueObjects;

public record EntityName
{
    public string Value { get; }

    public EntityName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío.");

        if (value.Length > 100)
            throw new ArgumentException("El nombre no puede exceder los 100 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
