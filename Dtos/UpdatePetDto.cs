using System.ComponentModel.DataAnnotations;

namespace PetProfile.Dtos;

public record class UpdatePetDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Nickname,
    [Required][StringLength(20)] string Gender,
    int SpeciesId,
    string SpeciesName,
    [Required] DateOnly BirthDate,
    string Breed,
    float Weight,
    string Color,
    string ImageName,
    string ImagePath
);