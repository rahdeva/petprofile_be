using PetProfile.Dtos;

namespace PetProfile.Endpoints;

public static class PetEndpoints
{
    const string GetPetEndpointName = "GetPet";

    private static readonly List<PetDto> pets = [
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

    public static WebApplication MapPetEndpoints(this WebApplication app){
        app.MapGet("/", () => "PetProfile API");

        app.MapGet("/api/pet", () => pets);

        app.MapGet("/api/pet/{id}", (int id) => {
            PetDto? pet = pets.Find(game => game.Id == id);

            return pet is null ? Results.NotFound() : Results.Ok(pet);
        })
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

            if(index == -1){
                return Results.NotFound();
            }

            pets[index] = new(
                id,
                updatedPet.Name,
                updatedPet.Gender,
                updatedPet.BirthDate
            );

            return Results.NoContent();
        });

        app.MapDelete("/api/pet/{id}", (int id) => {
            pets.RemoveAll(game => game.Id == id);
            
            return Results.NoContent();
        });

        return app;
    }
}
