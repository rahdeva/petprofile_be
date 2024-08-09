using System;
using PetProfile.Dtos;
using PetProfile.Entities;

namespace PetProfile.Mapping;

public static class PetMapping
{
    public static Pet ToEntity(this CreatePetDto pet){
        return new Pet(){
            Name = pet.Name,
            Gender = pet.Gender,
            SpeciesId = pet.SpeciesId,
            BirthDate = pet.BirthDate,
        };
    }

    public static PetSummaryDto ToPetSummaryDto(this Pet pet){
        return new (
            pet.Id,
            pet.Name,
            pet.Gender,
            pet.Species!.Name,
            pet.BirthDate
        );
    }

    public static PetDetailDto ToPetDetailDto(this Pet pet){
        return new (
            pet.Id,
            pet.Name,
            pet.Gender,
            pet.SpeciesId,
            pet.BirthDate
        );
    }

    public static Pet ToEntity(this UpdatePetDto pet, int id){
        return new Pet(){
            Id = id,
            Name = pet.Name,
            Gender = pet.Gender,
            SpeciesId = pet.SpeciesId,
            BirthDate = pet.BirthDate,
        };
    }
}
