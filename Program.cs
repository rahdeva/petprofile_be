using PetProfile.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetPetEndpointName = "GetPet";

List<PetDto> pets = [
    new (
        1,
        "Bonbon",
        "Male",
        new DateOnly(2012, 7, 15)
    ),
    new (
        2,
        "Popi",
        "Female",
        new DateOnly(2012, 7, 15)
    ),
    new (
        3,
        "Konyong",
        "Female",
        new DateOnly(2012, 7, 15)
    ),
];

app.MapGet("/", () => "PetProfile API");

app.MapGet("/api/pet", () => pets);

app.MapGet("/api/pet/{id}", (int id) => pets.Find(game => game.Id == id))
    .WithName(GetPetEndpointName);

app.MapPost("/api/pet", (CreatePetDto newPet) => {
    PetDto pet = new(
        pets.Count + 1,
        newPet.Name,
        newPet.Gender,
        newPet.BirthDate
    );

    pets.Add(pet);

    return Results.CreatedAtRoute(GetPetEndpointName, new { id = pet.Id}, pet);
});

app.MapPut("/api/pet/{id}", (int id, UpdatePetDto updatedPet) => {
    var index = pets.FindIndex(pet => pet.Id == id);

    pets[index] = new(
        id,
        updatedPet.Name,
        updatedPet.Gender,
        updatedPet.BirthDate
    );

    return Results.NoContent();
});

app.Run();
