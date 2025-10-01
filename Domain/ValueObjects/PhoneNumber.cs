namespace Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        // Validaciones básicas para un número de teléfono internacional
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El teléfono no puede estar vacío.");

        if (!value.StartsWith("+"))
            throw new ArgumentException("El teléfono debe comenzar con el signo '+' seguido del código de país.");

        // quitar el signo '+' y validar solo los dígitos
        var digits = value.Substring(1);

        if (!digits.All(char.IsDigit))
            throw new ArgumentException("El teléfono solo debe contener dígitos después del '+'.");

        if (digits.Length < 7 || digits.Length > 15)
            throw new ArgumentException("El teléfono debe tener entre 7 y 15 dígitos (sin contar el '+').");

        Value = value;
    }

    public override string ToString() => Value;
}
