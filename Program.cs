using PetProfile.Data;
using PetProfile.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("PetProfile");
builder.Services.AddSqlite<PetProfileContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "PetProfile API");
app.MapPetEndpoints();

app.MigrateDb();

app.Run();