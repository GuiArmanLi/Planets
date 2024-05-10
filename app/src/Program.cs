using Planets.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
