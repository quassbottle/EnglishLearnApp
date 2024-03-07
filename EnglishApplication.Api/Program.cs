using EnglishApplication.Application.Extensions;
using EnglishApplication.Common.Authentication.Extensions;
using EnglishApplication.Infrastructure.Extensions;
using EnglishApplication.Extensions;
using EnglishApplication.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuth();

builder.Services.AddJwtSettings();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

    
var app = builder.Build();

app.MigrateDatabase<DefaultDataContext>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();