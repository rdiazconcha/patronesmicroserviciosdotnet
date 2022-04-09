using Microsoft.AspNetCore.Mvc;

namespace Pdm.Patient.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> logger;

    public PatientController(ILogger<PatientController> logger)
    {
        this.logger = logger;
    }
}