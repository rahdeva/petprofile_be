using System;
using Microsoft.EntityFrameworkCore;
using PetProfile.Data;
using PetProfile.Mapping;

namespace PetProfile.Endpoints;

public static class SpeciesEndpoints
{
    public static RouteGroupBuilder MapSpeciesEndpoints(this WebApplication app){
        var group = app.MapGroup("/api/species");

        group.MapGet("/", async (PetProfileContext dbContext) => 
            await dbContext.Species
                .Select(species => species.ToDto())
                .AsNoTracking()
                .ToListAsync()
        );

        return group;
    }
}
