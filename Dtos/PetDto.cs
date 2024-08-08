namespace PetProfile.Dtos;

public record class PetDto(
    int Id, 
    string Name, 
    string Species,
    string Gender,
    DateOnly BirthDate
);
