using Microsoft.EntityFrameworkCore;
using PetProfile.Data;
using PetProfile.Dtos;
using PetProfile.Entities;
using PetProfile.Mapping;

namespace PetProfile.Endpoints;

public static class PetEndpoints
{
    const string GetPetEndpointName = "GetPet";

    public static WebApplication MapPetEndpoints(this WebApplication app){
        var petGroup = app.MapGroup("/api/pet")
            .WithParameterValidation();     

        petGroup.MapGet("/", (PetProfileContext dbContext) => 
            dbContext.Pet
                .Include(pet => pet.Species)
                .Select(pet => pet.ToPetSummaryDto())
                .AsNoTracking()
        );

        petGroup.MapGet("/{id}", (int id, PetProfileContext dbContext) => {
            Pet? pet = dbContext.Pet.Find(id);

            return pet is null 
                ? Results.NotFound() 
                : Results.Ok(pet.ToPetDetailDto());
        })
        .WithName(GetPetEndpointName);

        petGroup.MapPost("", (CreatePetDto newPet, PetProfileContext dbContext) => {
            Pet pet = newPet.ToEntity();

            dbContext.Pet.Add(pet);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
                GetPetEndpointName, 
                new { id = pet.Id}, 
                pet.ToPetDetailDto()
            );
        });

        petGroup.MapPut("/{id}", (int id, UpdatePetDto updatedPet, PetProfileContext dbContext) => {
            var existingPet = dbContext.Pet.Find(id);

            if(existingPet is null){
                return Results.NotFound();
            }

            dbContext.Entry(existingPet)
                .CurrentValues
                .SetValues(updatedPet.ToEntity(id));
            
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        petGroup.MapDelete("/{id}", (int id, PetProfileContext dbContext) => {
            dbContext.Pet
                .Where(pet => pet.Id == id)
                .ExecuteDelete();

            dbContext.SaveChanges();
            
            return Results.NoContent();
        });

        return app;
    }
}
