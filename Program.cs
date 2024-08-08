using PetProfile.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "PetProfile API");
app.MapPetEndpoints();

app.Run();