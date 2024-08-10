using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetProfile.Data;
using PetProfile.Dtos;
using PetProfile.Entities;
using PetProfile.Mapping;

namespace PetProfile.Endpoints
{
    public static class ImageEndpoints
    {
        public static WebApplication MapImageEndpoints(this WebApplication app)
        {
            app.MapPost("/api/image/upload", async (HttpContext httpContext, [FromForm] UploadImageDto imageDto, PetProfileContext dbContext) =>
            {
                if (imageDto.Image == null || imageDto.Image.Length == 0)
                {
                    return Results.BadRequest("No file uploaded.");
                }

                var fileName = imageDto.Image.FileName;
                var filePath = Path.Combine("wwwroot/images", fileName);

                // Ensure the directory exists
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                }

                // Save the file to the server
                using var stream = new FileStream(filePath, FileMode.Create);
                await imageDto.Image.CopyToAsync(stream);

                // Create and save the Image entity
                var image = imageDto.ToEntity(filePath);
                dbContext.Images.Add(image);
                await dbContext.SaveChangesAsync();

                return Results.Ok(new { image.FileName, image.FilePath });
            });

            return app;
        }
    }
}
