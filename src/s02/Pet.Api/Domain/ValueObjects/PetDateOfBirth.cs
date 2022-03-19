namespace Pet.Api.Domain.ValueObjects;

public record PetDateOfBirth
{
    public DateTime Value { get; init; }
    internal PetDateOfBirth(DateTime value)
    {
        Value = value;
    }

    public static PetDateOfBirth Create(DateTime value)
    {
        return new PetDateOfBirth(value);
    }

    private void Validate(DateTime value)
    {
        if (value > DateTime.Now)
        {
            throw new ArgumentOutOfRangeException("Date of birth is not valid");
        }
    }
}
