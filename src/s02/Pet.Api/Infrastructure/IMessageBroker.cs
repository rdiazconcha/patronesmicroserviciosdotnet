using Pet.Api.Domain.Events;

namespace Pet.Api.Infrastructure;

public interface IMessageBroker
{
    bool Publish(IDomainEvent domainEvent);
}