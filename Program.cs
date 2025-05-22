using BibliotecaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

// // Registrar serviços no contêiner de DI
// builder.Services.AddSingleton<ITutorService, TutorService>();
// builder.Services.AddSingleton<IPetService, PetService>();

// Registrar os Repositories
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();

builder.Services.AddControllers();

// Swagger para documentação
// comando -> dotnet add package Swashbuckle.AspNetCore
// http://localhost:5183/swagger/index.html
// Link para acessar Swagger Browser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Registrar Controllers
app.MapControllers();

app.Run();