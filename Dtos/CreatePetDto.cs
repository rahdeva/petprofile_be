using System.ComponentModel.DataAnnotations;

namespace PetProfile.Dtos;

public record class CreatePetDto(
    [Required][StringLength(50)] string Name, 
    [Required][StringLength(20)] string Gender,
    int SpeciesId,
    [Required] DateOnly BirthDate
);