using System;
using Microsoft.EntityFrameworkCore;

namespace PetProfile.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PetProfileContext>();
        dbContext.Database.Migrate();
    }
}
