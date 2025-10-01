namespace Domain.ValueObjects;
public class Role
{
    public string Value { get; }
    public Role(string value)
    {
        // definir que el rol sea admin o user
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El rol no puede estar vacío.");
        else if (value.Contains(" "))
            throw new ArgumentException("El rol no puede contener espacios.");
        else if (value != "admin" && value != "user")
            throw new ArgumentException("El rol debe ser 'admin' o 'user'.");
        Value = value;
    }
}
