namespace PetProfile.Dtos;

public record class PetSummaryDto(
    int Id, 
    string Name, 
    string Nickname, 
    string Gender,
    string SpeciesName,
    string ImagePath
);
