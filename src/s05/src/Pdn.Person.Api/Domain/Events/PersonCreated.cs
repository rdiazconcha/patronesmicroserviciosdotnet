using Pdm.Core;

namespace Pdm.Person.Api.Domain.Events;

public record PersonCreated(Guid Id) : IDomainEvent;