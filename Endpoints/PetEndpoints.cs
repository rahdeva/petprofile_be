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
        var petGroup = app.MapGroup("/api/pet")
            .WithParameterValidation();     

        petGroup.MapGet("/", () => pets);

        petGroup.MapGet("/{id}", (int id) => {
            PetDto? pet = pets.Find(game => game.Id == id);

            return pet is null ? Results.NotFound() : Results.Ok(pet);
        })
            .WithName(GetPetEndpointName);

        petGroup.MapPost("", (CreatePetDto newPet) => {
            PetDto pet = new(
                pets.Count + 1,
                newPet.Name,
                newPet.Gender,
                newPet.BirthDate
            );

            pets.Add(pet);

            return Results.CreatedAtRoute(GetPetEndpointName, new { id = pet.Id}, pet);
        })
        .WithParameterValidation();

        petGroup.MapPut("/{id}", (int id, UpdatePetDto updatedPet) => {
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

        petGroup.MapDelete("/{id}", (int id) => {
            pets.RemoveAll(game => game.Id == id);
            
            return Results.NoContent();
        });

        return app;
    }
}
