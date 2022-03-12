using Pet.Api.Domain.ValueObjects;

namespace Pet.Api.Domain.Entities;

public class Pet
{
    public Guid Id { get; init; }

    public PetName Name { get; private set; }

    public PetDateOfBirth DateOfBirth { get; private set; }

    private Pet()
    {

    }

    public void SetName(PetName name)
    {
        Name = name;
    }

}