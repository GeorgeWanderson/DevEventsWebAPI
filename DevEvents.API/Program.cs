using DevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<EventosDbContext>();


// Utilizando o EFCore com o InMemory
//builder.Services.AddDbContext<EventosDbContext>(
//    o => o.UseInMemoryDatabase("DevEventosDb")
//);


// Utilizando o EFCore com SQL Server
var connectionString = builder.Configuration.GetConnectionString("DevEventos");
builder.Services.AddDbContext<EventosDbContext>(
    o => o.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
