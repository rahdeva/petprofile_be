using System.ComponentModel.DataAnnotations;

namespace PetProfile.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public required string FileName { get; set; }
        public required string FilePath { get; set; }
    }
}
