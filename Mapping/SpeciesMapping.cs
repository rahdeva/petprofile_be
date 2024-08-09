using System;
using PetProfile.Dtos;
using PetProfile.Entities;

namespace PetProfile.Mapping;

public static class SpeciesMapping
{
    public static SpeciesDto ToDto(this Species species){
        return new SpeciesDto(
            species.Id,
            species.Name
        );
    }
}
