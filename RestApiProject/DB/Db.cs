using RestApiProject.Models;
namespace RestApiProject.DB;

public static class Db
{
    public static List<Animal> Animals = new()
    {
        new Animal { Id = 1, Name = "Max", Category = "Dog", Weight = 10.5, FurColor = "Brown" },
        new Animal { Id = 2, Name = "Fluffy", Category = "Cat", Weight = 5.2, FurColor = "White" }
    };
    public static List<Visit> Visits = new()
    {
        new Visit { Id = 1, VisitDate = DateTime.Now.AddDays(-10), Animal = Animals.First(a => a.Id == 1), Description = "Regular checkup", Price = 50 },
        new Visit { Id = 2, VisitDate = DateTime.Now.AddDays(-5), Animal = Animals.First(a => a.Id == 2), Description = "Vaccination", Price = 30 }
    };
}