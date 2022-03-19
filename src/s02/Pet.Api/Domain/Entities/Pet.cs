using Pet.Api.Domain.Events;
using Pet.Api.Domain.ValueObjects;

namespace Pet.Api.Domain.Entities;

public class Pet
{
    private List<IDomainEvent> events = new List<IDomainEvent>();
    public Guid Id { get; init; }

    public PetName Name { get; private set; }

    public PetDateOfBirth DateOfBirth { get; private set; }

    private Pet()
    {

    }

    public void SetName(PetName name)
    {
        Name = name;
        var newEvent = new PetNameChanged(name.Value);
        events.Add(newEvent);
    }

}