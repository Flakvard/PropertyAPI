using Microsoft.AspNetCore.Mvc;

namespace PropertyAPI.Api.Controllers;

[Route("[controller]")]
public class PropertiesController : ApiController
{
    [HttpGet]
    public IActionResult ListProperties()
    {
        return Ok(Array.Empty<string>());
    }
}