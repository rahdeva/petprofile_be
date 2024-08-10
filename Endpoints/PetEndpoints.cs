using Microsoft.AspNetCore.Mvc;
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

        petGroup.MapGet("/", async (PetProfileContext dbContext) => 
            await dbContext.Pet
                .Include(pet => pet.Species)
                .Select(pet => pet.ToPetSummaryDto())
                .AsNoTracking()
                .ToListAsync()
        );

        petGroup.MapGet("/{id}", async (int id, PetProfileContext dbContext) => {
            Pet? pet = await dbContext.Pet
                .FindAsync(id);

            return pet is null 
                ? Results.NotFound() 
                : Results.Ok(pet.ToPetDetailDto());
        })
        .WithName(GetPetEndpointName);

        petGroup.MapPost("", async (CreatePetDto newPet, PetProfileContext dbContext) => {
            var pet = newPet.ToEntity();

            dbContext.Pet.Add(pet);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetPetEndpointName,
                new { id = pet.Id },
                pet.ToPetDetailDto()
            );
        });

        petGroup.MapPut("/{id}", async (int id, UpdatePetDto updatedPet, PetProfileContext dbContext) => {
            var existingPet = await dbContext.Pet.FindAsync(id);

            if(existingPet is null){
                return Results.NotFound();
            }

            dbContext.Entry(existingPet)
                .CurrentValues
                .SetValues(updatedPet.ToEntity(id));
            
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        petGroup.MapDelete("/{id}", async (int id, PetProfileContext dbContext) => {
            var pet = await dbContext.Pet.FindAsync(id);

            if (pet is null)
            {
                return Results.NotFound();
            }

            await dbContext.Pet
                .Where(pet => pet.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return app;
    }
}
