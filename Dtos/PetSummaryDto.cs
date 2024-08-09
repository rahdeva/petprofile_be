namespace PetProfile.Dtos;

public record class PetSummaryDto(
    int Id, 
    string Name, 
    string Gender,
    string Species,
    DateOnly BirthDate
);
