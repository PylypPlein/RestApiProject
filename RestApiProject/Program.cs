using Microsoft.AspNetCore.Mvc;
using RestApiProject.DB;
using RestApiProject.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/api/animals", () =>
{
    return Results.Ok(Db.Animals);
});

app.MapGet("/api/animals/{id:int}", (int id) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/api/animals", ([FromBody] Animal animal) =>
{
    Db.Animals.Add(animal);
    return Results.Created($"/api/animals/{animal.Id}", animal);
});

app.MapPut("/api/animals/{id:int}", (int id, [FromBody] Animal data) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal is null) return Results.NotFound($"Animal with id {id} not found");

    animal.Name = data.Name;
    animal.Category = data.Category;
    animal.Weight = data.Weight;
    animal.FurColor = data.FurColor;
    return Results.Ok(animal);
});

app.MapDelete("/api/animals/{id:int}", (int id) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal is null) return Results.NotFound($"Animal with id {id} not found");

    Db.Animals.Remove(animal);
    return Results.Ok();
});

app.MapGet("/api/animals/{id:int}/visits", (int id) =>
{
    var visits = Db.Visits.Where(v => v.Animal.Id == id);
    return Results.Ok(visits);
});

app.MapPost("/api/animals/{id:int}/visits", (int id, [FromBody] Visit visit) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal is null) return Results.NotFound($"Animal with id {id} not found");

    visit.Animal = animal;
    Db.Visits.Add(visit);
    return Results.Created($"/api/animals/{id}/visits/{visit.Id}", visit);
});

app.UseHttpsRedirection();

app.Run();