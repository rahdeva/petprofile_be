using System;
using Microsoft.EntityFrameworkCore;
using PetProfile.Entities;

namespace PetProfile.Data;

public class PetProfileContext(DbContextOptions<PetProfileContext> options) : DbContext (options)
{
    public DbSet<Pet> Pet => Set<Pet>();
    public DbSet<Species> Species => Set<Species>();
}
