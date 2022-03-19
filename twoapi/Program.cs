var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(o => o.ListenAnyIP(5001));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
