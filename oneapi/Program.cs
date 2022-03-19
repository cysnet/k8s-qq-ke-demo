var builder = WebApplication.CreateBuilder();

builder.WebHost.ConfigureKestrel(o => o.ListenAnyIP(5000));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


//docker build -t oneapi -f ./oneapi/Dockerfile .

//docker run --name oneapi -d -p 5000:5000 oneapi