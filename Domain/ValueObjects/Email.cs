namespace Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email no puede estar vacío.");

        if (!value.Contains("@") || !value.Contains("."))
            throw new ArgumentException("Formato de email inválido.");

        Value = value;
    }

    public override string ToString() => Value;
}
