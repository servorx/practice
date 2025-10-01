namespace Domain.ValueObjects;

public record Email
{
    public string Value { get; }
    public Email(string value)
    {
        // estas son las validaciones que se van a aplicar
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email no puede estar vacío.");
        else if (!value.Contains("@") || !value.Contains("."))
            throw new ArgumentException("Formato de email inválido.");
        else if (value.Length < 5)
            throw new ArgumentException("El email debe tener al menos 5 caracteres.");
        else if (value.Length > 80)
            throw new ArgumentException("El email no puede exceder los 100 caracteres.");

        Value = value;
    }

    public override string ToString() => Value;
}
