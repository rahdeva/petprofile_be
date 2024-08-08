namespace PetProfile.Dtos;

public record class CreatePetDto(
    string Name, 
    string Gender,
    DateOnly BirthDate
)
{

}
