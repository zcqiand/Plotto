using Microsoft.AspNetCore.Mvc;
using UltraNuke.Plotto.Api.Services;

namespace UltraNuke.Plotto.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{

    private readonly ILogger<TestController> logger;

    public TestController(ILogger<TestController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public string GetExample()
    {
        var ps = new ProgramServices(logger);
        return ps.print_story();
    }
}