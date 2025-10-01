namespace Domain.ValueObjects;
public class Password
{
    public string Value { get; }
    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La contraseña no puede estar vacía.");
        else if (value.Length < 8)
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        else if (value.Length > 128)
            throw new ArgumentException("La contraseña no puede exceder los 128 caracteres.");
        else if (value.Any(char.IsLower))
            throw new ArgumentException("La contraseña debe contener al menos una mayúscula.");
        else if (value.Any(char.IsUpper))
            throw new ArgumentException("La contraseña debe contener al menos una minúscula.");
        else if (value.Any(char.IsDigit))
            throw new ArgumentException("La contraseña debe contener al menos un número.");
        else if (value.All(char.IsLetterOrDigit))
            throw new ArgumentException("La contraseña debe contener al menos un carácter especial.");
        Value = value;
    }
}
