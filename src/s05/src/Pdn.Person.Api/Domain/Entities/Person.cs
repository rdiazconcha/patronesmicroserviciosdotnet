using Pdm.Core;
using Pdm.Person.Api.Domain.Events;
using Pdm.Person.Api.Domain.ValueObjects;

namespace Pdm.Person.Api.Domain.Entities;

public class Person
{
    private List<IDomainEvent> domainEvents = new List<IDomainEvent>();
    public Guid Id { get; init; }

    public PersonName Name { get; private set; }

    public Person()
    {
        Id = Guid.NewGuid();
        domainEvents.Add(new PersonCreated(Id));
    }

    public void SetName(PersonName name)
    {
        Name = name;
    }
}