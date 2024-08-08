namespace PetProfile.Dtos;

public record class UpdatePetDto(
    string Name, 
    string Gender,
    DateOnly BirthDate
)
{

}
