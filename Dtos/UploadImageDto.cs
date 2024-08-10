using System.ComponentModel.DataAnnotations;

namespace PetProfile.Dtos
{
    public record class UploadImageDto(
        [Required] IFormFile Image
    );
}