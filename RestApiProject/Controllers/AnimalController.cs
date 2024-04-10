using Microsoft.AspNetCore.Mvc;
using RestApiProject.DB;
namespace RestApiProject.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetAllAnimals()
    {
        return Ok(Db.Animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
    {
        //
        return Ok();
    }
}