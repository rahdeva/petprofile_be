using PetProfile.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<PetDto> petDtos = [
    new (
        1,
        "Bonbon",
        "Male",
        new DateOnly(2012, 7, 15)
    ),
    new (
        2,
        "Popi",
        "Female",
        new DateOnly(2012, 7, 15)
    ),
    new (
        3,
        "Konyong",
        "Female",
        new DateOnly(2012, 7, 15)
    ),
];

app.MapGet("/", () => "Hello Deva!");

app.MapGet("/api/pet", () => petDtos);

app.MapGet("/api/pet/{id}", (int id) => petDtos.Find(game => game.Id == id));

app.Run();
