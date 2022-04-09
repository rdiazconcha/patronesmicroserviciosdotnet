using Microsoft.AspNetCore.Mvc;
using Pdm.Person.Api.Domain.Commands;
using Pdm.Person.Api.Domain.ValueObjects;
using Pdm.Person.Api.Infrastructure;

namespace Pdm.Person.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly PersonDbContext dbContext;

    public PersonController(ILogger<PersonController> logger,
        PersonDbContext dbContext)
    {
        this.logger = logger;
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePersonCommand command)
    {
        var person = await CreatePersonAndPublishEventAsync(command);
        return Ok(person.Id);
    }

    private async Task<Domain.Entities.Person> CreatePersonAndPublishEventAsync(CreatePersonCommand command)
    {
        var person = new Domain.Entities.Person();
        person.SetName(PersonName.Create(command.FirstName, command.LastName));
        dbContext.People.Add(person);
        await dbContext.SaveChangesAsync();

        return person;
    }
}