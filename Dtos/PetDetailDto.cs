namespace PetProfile.Dtos;

public record class PetDetailDto(
    int Id,
    string Name,
    string Nickname,
    string Gender,
    int SpeciesId,
    string SpeciesName,
    string Breed,
    DateOnly BirthDate,
    float Weight,
    string Color,
    string ImageName,
    string ImagePath
);
