namespace Domain.ValueObjects;

public record ContactName
{
    public string Value { get; }

    public ContactName(string value)
    {
        // estas son las validaciones que se van a aplicar
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de contacto no puede estar vacío.");
        else if (value.Length < 2)
            throw new ArgumentException("El nombre de contacto debe tener al menos 2 caracteres.");
        else if (value.Length > 50)
            throw new ArgumentException("El nombre de contacto no puede exceder los 50 caracteres.");  

        Value = value;
    }

    public override string ToString() => Value;
}
