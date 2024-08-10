using System;namespace PetProfile.Entities;

public class Pet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Nickname { get; set; }
    public int SpeciesId { get; set; }
    public required string SpeciesName{ get; set; }
    public Species? Species { get; set; }
    public required string Breed { get; set; }
    public required string Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public required float Weight { get; set; }
    public required string Color { get; set; }
    public required string ImageName { get; set; }
    public required string ImagePath { get; set; }
}
