using Api.Extensions;
using Api.Validators; // Para FluentValidation
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddOpenApi();

// CORS
builder.Services.ConfigureCors();

// Rate Limiter
builder.Services.AddCustomRateLimiter();

// Application Services (UnitOfWork, repos, etc.)
builder.Services.AddApplicationServices();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("Postgres")!;
    options.UseNpgsql(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// UnitOfWork
builder.Services.AddScoped<Application.Abstractions.IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Api.Mappings.CompanyProfile).Assembly);

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Companies.CreateCompany).Assembly));

// FluentValidation: registramos todos los Validators en el ensamblado de Api.Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateBranchDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("CorsPolicy");
app.UseCors("CorsPolicyUrl");
app.UseCors("Dinamica");

app.UseHttpsRedirection();
app.UseRateLimiter();
app.UseAuthorization();

app.MapControllers();

// Migraciones automáticas
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.Migrate();

app.Run();
