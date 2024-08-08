namespace PetProfile.Dtos;

public record class PetDto(
    int Id, 
    string Name, 
    string Gender,
    DateOnly BirthDate
){

}
