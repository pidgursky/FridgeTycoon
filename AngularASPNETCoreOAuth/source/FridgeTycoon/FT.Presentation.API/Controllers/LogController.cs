using FT.Presentation.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]/[action]")]
public class LogController : Controller
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into Controller");
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Hello, this is the index!");
        return Ok();
    }
}


