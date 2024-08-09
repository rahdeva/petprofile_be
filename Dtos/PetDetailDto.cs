namespace PetProfile.Dtos;

public record class PetDetailDto(
    int Id, 
    string Name,
    string Gender,
    int SpeciesId,
    DateOnly BirthDate
);
