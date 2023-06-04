using Microsoft.AspNetCore.Mvc;
using TemplateWebAPI.Models;
using TemplateWebAPI.Services.Interfaces;

namespace TemplateWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : Controller
{
    private readonly ISingletonService _singleton;
    private readonly IScopedService _scoped;
    private readonly ITransientService _transient;

    public TestController(ISingletonService singleton, IScopedService scoped, ITransientService transient)
    {
        _singleton = singleton;
        _scoped = scoped;
        _transient = transient;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("\n!!!!!!!! TEST CONTROLLER !!!!!!!");
        Console.WriteLine($"Singleton UID\t\t{_singleton.ServiceUniqueId}");
        Console.WriteLine($"Scoped UID\t\t{_scoped.ServiceUniqueId}");
        Console.WriteLine($"Transient UID\t\t{_transient.ServiceUniqueId}");

        return Ok();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Pet> GetById(int id, bool dogsOnly)
    {

        var pet = new Pet()
        {
            Id = 1
        };
        return new ActionResult<Pet>(pet);
    }
    
}