using EnglishApplication.Extensions;
using EnglishApplication.Infrastructure.Persistence.Context;
using EnglishApplication.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuth();

builder.Services.AddAuthModule();
builder.Services.AddJwtAuth(builder.Configuration);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

app.MigrateDatabase<DefaultDataContext>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();