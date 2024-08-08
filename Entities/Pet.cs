using System;

namespace PetProfile.Entities;

public class Pet
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int SpeciesId { get; set; }

    public Species? Species { get; set; }

    public required string Gender { get; set; }

    public DateOnly BirthDate { get; set; }
}
