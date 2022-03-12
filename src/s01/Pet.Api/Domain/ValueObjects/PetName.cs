namespace Pet.Api.Domain.ValueObjects;

public record PetName //C# 10
{
    public string Value { get; init; }

    internal PetName(string value)
    {
        Value = value;
    }

    public static PetName Create(string value)
    {
        return new PetName(value);
    }

    private static void Validate(string value)
    {
        if (value.Length > 50)
        {
            throw new ArgumentOutOfRangeException("Name must not be more than 50 characters");
        }
    }
}
