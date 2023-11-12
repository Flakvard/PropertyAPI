using Microsoft.AspNetCore.Mvc;

namespace PropertyAPI.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error(){
        return Problem();
    }
}