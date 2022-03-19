using Pet.Api.Domain.Events;
using Pet.Api.Domain.ValueObjects;

namespace Pet.Api.Domain.Entities;

public class Pet
{
    private List<IDomainEvent> events = new List<IDomainEvent>();

    public ICollection<IDomainEvent> DomainEvents => events;
    public Guid Id { get; init; }

    public PetName Name { get; private set; }

    public PetDateOfBirth DateOfBirth { get; private set; }

    private Pet()
    {
    }

    public Pet(PetName petName)
    {
        SetName(petName);
    }

    public void SetName(PetName name)
    {
        Name = name;
        var newEvent = new PetNameChanged(name.Value);
        events.Add(newEvent);
    }
}