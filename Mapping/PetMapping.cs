using System;
using PetProfile.Dtos;
using PetProfile.Entities;

namespace PetProfile.Mapping;

public static class PetMapping
{
    public static Pet ToEntity(this CreatePetDto petDto){
        return new Pet
        {
            Name = petDto.Name,
            Nickname = petDto.Nickname,
            Gender = petDto.Gender,
            SpeciesId = petDto.SpeciesId,
            SpeciesName = petDto.SpeciesName,
            BirthDate = petDto.BirthDate,
            Breed = petDto.Breed,
            Weight = petDto.Weight,
            Color = petDto.Color,
            ImageName = petDto.ImageName,
            ImagePath = petDto.ImagePath 
        };
    }

    public static Pet ToEntity(this UpdatePetDto petDto, Pet existingPet){
        existingPet.Name = petDto.Name;
        existingPet.Nickname = petDto.Nickname;
        existingPet.Gender = petDto.Gender;
        existingPet.SpeciesId = petDto.SpeciesId;
        existingPet.BirthDate = petDto.BirthDate;
        existingPet.Breed = petDto.Breed;
        existingPet.Weight = petDto.Weight;
        existingPet.Color = petDto.Color;
        existingPet.ImageName = petDto.ImageName;
        existingPet.ImagePath = petDto.ImagePath;

        return existingPet;
    }

    public static PetSummaryDto ToPetSummaryDto(this Pet pet){
        return new (
            pet.Id,
            pet.Name,
            pet.Nickname,
            pet.Gender,
            pet.Species!.Name,
            pet.ImagePath
        );
    }

    public static PetDetailDto ToPetDetailDto(this Pet pet){
        return new (
            pet.Id,
            pet.Name,
            pet.Nickname,
            pet.Gender,
            pet.SpeciesId,
            pet.SpeciesName,
            pet.Breed,
            pet.BirthDate,
            pet.Weight,
            pet.Color,
            pet.ImageName,
            pet.ImagePath
        );
    }

    public static Pet ToEntity(this UpdatePetDto pet, int id){
        return new Pet(){
            Id = id,
            Name = pet.Name,
            Nickname = pet.Nickname,
            Gender = pet.Gender,
            SpeciesId = pet.SpeciesId,
            SpeciesName = pet.SpeciesName,
            BirthDate = pet.BirthDate,
            Breed = pet.Breed,
            Weight = pet.Weight,
            Color = pet.Color,
            ImageName = pet.ImageName,
            ImagePath = pet.ImagePath 
        };
    }
}
