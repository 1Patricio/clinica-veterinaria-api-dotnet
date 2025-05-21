var builder = WebApplication.CreateBuilder(args);

// Registrar serviços no contêiner de DI
builder.Services.AddSingleton<ITutorService, TutorService>();
builder.Services.AddSingleton<IPetService, PetService>();

builder.Services.AddControllers();

// Swagger para documentação
// comando -> dotnet add package Swashbuckle.AspNetCore
// http://localhost:5183/swagger/index.html
// Link para acessar Swagger Browser
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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