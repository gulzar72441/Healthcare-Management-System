using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
// Add DbContext with SQL Server
builder.Services.AddDbContext<HealthcareSystem.Infrastructure.Persistence.HealthcareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IDoctorRepository, HealthcareSystem.Infrastructure.Repositories.DoctorRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IPharmacyRepository, HealthcareSystem.Infrastructure.Repositories.PharmacyRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.INotificationService, HealthcareSystem.Infrastructure.Services.NotificationService>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IPatientRepository, HealthcareSystem.Infrastructure.Repositories.PatientRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IAppointmentRepository, HealthcareSystem.Infrastructure.Repositories.AppointmentRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IBillRepository, HealthcareSystem.Infrastructure.Repositories.BillRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IMedicalRecordRepository, HealthcareSystem.Infrastructure.Repositories.MedicalRecordRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.ILabOrderRepository, HealthcareSystem.Infrastructure.Repositories.LabOrderRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.INotificationRepository, HealthcareSystem.Infrastructure.Repositories.NotificationRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IPrescriptionRepository, HealthcareSystem.Infrastructure.Repositories.PrescriptionRepository>();
builder.Services.AddScoped<HealthcareSystem.Domain.Interfaces.IUserRepository, HealthcareSystem.Infrastructure.Repositories.UserRepository>();


// Register services
builder.Services.AddScoped<HealthcareSystem.Application.Auth.Interfaces.IJwtService, HealthcareSystem.Infrastructure.Services.JwtService>();
builder.Services.AddScoped<HealthcareSystem.Application.Pharmacy.Interfaces.IPharmacyService, HealthcareSystem.Infrastructure.Services.PharmacyService>();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR for Application layer
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(HealthcareSystem.Application.AssemblyReference).Assembly));
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(HealthcareSystem.Application.AssemblyReference).Assembly);
// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<HealthcareSystem.Application.DTOs.PatientDto>();

// Register Serilog
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

// TODO: Configure Serilog sinks and enrichers as needed

// Add JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add role-based authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("DoctorOnly", policy => policy.RequireRole("Doctor"));
    options.AddPolicy("PatientOnly", policy => policy.RequireRole("Patient"));
});

var app = builder.Build();

// Seed database at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HealthcareSystem.Infrastructure.Persistence.HealthcareDbContext>();
    HealthcareSystem.Infrastructure.Persistence.DbSeeder.Seed(dbContext);
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { } // 👈 Makes Program accessible to tests