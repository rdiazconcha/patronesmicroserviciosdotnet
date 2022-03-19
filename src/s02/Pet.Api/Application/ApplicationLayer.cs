using Pet.Api.Domain.ValueObjects;
using Pet.Api.Infrastructure;

namespace Pet.Api.Application;

public class ApplicationLayer
{
    private readonly IMessageBroker messageBroker;

    public ApplicationLayer(IMessageBroker messageBroker)
    {
        this.messageBroker = messageBroker;
    }

    public void SetPetName(string name)
    {
        var newPetName = PetName.Create(name);
        var pet = new Pet.Api.Domain.Entities.Pet(newPetName);
    }

}
