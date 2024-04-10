using Microsoft.AspNetCore.Mvc;
using RestApiProject.DB;
namespace RestApiProject.Controllers;

[ApiController]
[Route("api/animals")]
public class StudentController : ControllerBase
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