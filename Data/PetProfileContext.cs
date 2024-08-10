using System;
using Microsoft.EntityFrameworkCore;
using PetProfile.Entities;

namespace PetProfile.Data;

public class PetProfileContext(DbContextOptions<PetProfileContext> options) : DbContext (options)
{
    public DbSet<Pet> Pet => Set<Pet>();
    public DbSet<Species> Species => Set<Species>();

    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Species>().HasData(
            new {Id = 1, Name = "Dog"},
            new {Id = 2, Name = "Cat"},
            new {Id = 3, Name = "Bird"},
            new {Id = 4, Name = "Hamster"},
            new {Id = 5, Name = "Snake"}
        );
    }
}
