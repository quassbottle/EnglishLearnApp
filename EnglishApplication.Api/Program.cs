using EnglishApplication.Infrastructure.Extensions;
using EnglishApplication.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();

var app = builder.Build();

app.MigrateDatabase<DefaultDataContext>();

app.UseSwagger(); 
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();