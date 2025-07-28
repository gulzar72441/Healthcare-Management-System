# Healthcare Management System

## Overview
A full-featured, modular, and scalable Healthcare Management System built using ASP.NET Core 9.0 Web API, following strict Hexagonal Architecture (Ports & Adapters) and API-first design. SQL Server is used as the primary data store.

### Key Features
- Patient, Doctor, Appointment, Prescription, EMR, Billing, Lab, Pharmacy, Notification, Auth, and Dashboard modules
- Hexagonal Architecture (Ports & Adapters)
- CQRS with MediatR for decoupling and scalability
- Entity Framework Core for data access
- JWT Authentication & Role-based Authorization
- AutoMapper, Serilog, FluentValidation, MailKit, Twilio integrations
- Modular, testable, and maintainable codebase

### Usage
- Register as a patient or doctor to access the system
- Book appointments, view prescriptions, and manage medical records
- Access billing, lab, and pharmacy services
- Receive notifications and updates on appointments and prescriptions

## Solution Structure
```
HealthcareSystem/
│
├── src/
│   ├── HealthcareSystem.Domain/         # Entities, Value Objects, Domain Interfaces
│   ├── HealthcareSystem.Application/    # Use Cases, Services, DTOs, Ports
│   ├── HealthcareSystem.Infrastructure/ # EF Core, Repositories, External APIs, Adapters
│   └── HealthcareSystem.WebAPI/         # Controllers, Models, Middleware, Adapters
│
├── tests/
│   ├── HealthcareSystem.UnitTests/      # Unit Tests
│   └── HealthcareSystem.IntegrationTests/ # Integration Tests
│
└── README.md
```

## Hexagonal Architecture
- **Domain**: Pure business logic, entities, value objects, and domain interfaces.
- **Application**: Use cases, DTOs, service interfaces (ports), CQRS handlers.
- **Infrastructure**: EF Core DbContext, repositories, and external services (adapters).
- **WebAPI**: HTTP API, controllers, middleware, request/response models.
- **All dependencies flow inward; core domain is isolated from infrastructure/web.**

## CQRS with MediatR
- Command Query Responsibility Segregation (CQRS) pattern for decoupling and scalability
- MediatR library for handling commands and queries

## Seeding Initial Data
- The system seeds initial patients, doctors, and specialties on first run
- Initial data is used for demonstration purposes and can be modified or removed as needed

## Technology Stack
- ASP.NET Core 9.0 Web API
- SQL Server, Entity Framework Core
- MediatR, AutoMapper, Serilog, FluentValidation
- JWT Auth, MailKit, Twilio, Swagger

## Setup Instructions

### 1. Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 2. Database Setup & Migrations
```
dotnet tool install --global dotnet-ef
cd src/HealthcareSystem.Infrastructure
# Update connection string in appsettings.json
# Run migrations:
dotnet ef database update
```

### 3. Running the App
```
cd src/HealthcareSystem.WebAPI
dotnet run
```
The API will be available at `https://localhost:5001` (or as configured).

### 4. Running Tests
```
dotnet test ../..
```

### 5. API Documentation
- Swagger UI available at `/swagger` endpoint when running the WebAPI project.

### 6. Troubleshooting
- Check the logs for errors and exceptions
- Verify database connection and migration status
- Consult the documentation and code for implementation details

### 7. Contributing
- Follow Hexagonal Architecture strictly: no direct dependency from Domain/Application to Infrastructure/Web.
- Add new modules as separate folders and interfaces.
- Use CQRS with MediatR for decoupling and scalability.
- Seed initial data for demonstration purposes.

---

For any questions or issues, please contact the maintainers.
