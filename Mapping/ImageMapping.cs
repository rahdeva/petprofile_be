using PetProfile.Dtos;
using PetProfile.Entities;

namespace PetProfile.Mapping
{
public static class ImageMapping{
    public static Image ToEntity(this UploadImageDto imageDto, string filePath){
        return new Image{
                FileName = imageDto.Image.FileName,
                FilePath = filePath
            };
        }
    }
}
