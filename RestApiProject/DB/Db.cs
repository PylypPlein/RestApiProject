using RestApiProject.Models;
namespace RestApiProject.DB;

public static class Db
{
    public static List<Animal> Animals = new()
    {
        new Animal { Id = 1, Name = "Max", Category = "Dog", Weight = 10.5, FurColor = "Brown" },
        new Animal { Id = 2, Name = "Fluffy", Category = "Cat", Weight = 5.2, FurColor = "White" }
    };
}