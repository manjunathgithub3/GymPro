# GymPro Backend - Project Folder Structure

This document lists the folder and key file structure for each project in the `Backend` solution.

## Solution

- GymPro.slnx

## GymPro.API (Web / API Host)

- Controllers/
- Endpoints/
- Middleware/
- Filters/
- Extensions/
- DependencyInjection/
- HealthChecks/
- Logs/
- Options/
- Configurations/
- Constants/
- Program.cs
- appsettings.json
- Properties/launchSettings.json
- GymPro.API.csproj
- GymPro.API.http

## GymPro.Application (Application / Business Logic)

- Behaviors/
- Features/
- Services/
- Validators/
- Mappings/
- Exceptions/
- Interfaces/
- Common/
- DependencyInjection/ApplicationServiceRegistration.cs
- GymPro.Application.csproj

## GymPro.Contracts (DTOs and Contracts)

- Contracts/
- DTOs/
- Requests/
- Responses/
- Enums/
- GymPro.Contracts.csproj

## GymPro.Domain (Domain Layer)

- Entities/
- ValueObjects/
- Events/
- Enums/
- Exceptions/
- Common/
- GymPro.Domain.csproj

## GymPro.Infrastructure (Infrastructure implementations)

- DependencyInjection/InfrastructureServiceRegistration.cs
- Identity/
- Jwt/
- Services/
- Storage/
- Email/
- Logging/
- Infrastructure/
- GymPro.Infrastructure.csproj

## GymPro.Persistence (EF Core / Data Access)

- Contexts/GymProDbContext.cs
- Migrations/
- Repositories/
- Configurations/
- Interceptors/
- Persistence/
- Seed/
- DependencyInjection/PersistenceServiceRegistration.cs
- GymPro.Persistence.csproj

## GymPro.Shared (Shared utilities)

- Constants/
- Enums/
- Extensions/
- Helpers/
- Responses/ApiResponse.cs
- GymPro.Shared.csproj

---

If you'd like, I can:
- expand each folder to list every file found, or
- generate a tree-style output for each project, or
- create a Mermaid diagram of project boundaries and dependencies.
========================================================================

Multi-tenancy + Authentication + Members + Memberships + Attendance + Trainers + Inquiries
=========================================================================
MVP Databases:
CORE
├── Gyms
├── Users
├── Roles
├── UserRoles
└── RefreshTokens

MEMBERS
└── Members

MEMBERSHIP
├── MembershipPlans
└── MemberMemberships

OPERATIONS
├── Attendances
└── TrainerProfiles

CRM
└── Inquiries
Relationship diagram
                         ┌──────────────┐
                         │    Gyms      │
                         │   Tenant     │
                         └──────┬───────┘
                                │
           ┌────────────────────┼─────────────────────┐
           │                    │                     │
           ▼                    ▼                     ▼
       ┌────────┐          ┌──────────┐        ┌──────────────┐
       │ Users  │          │ Members  │        │    Roles     │
       └───┬────┘          └────┬─────┘        └──────┬───────┘
           │                    │                     │
           │                    │                     │
       ┌───▼──────┐             │               ┌─────▼─────┐
       │ UserRoles│             │               │ UserRoles │
       └──────────┘             │               └───────────┘
                                │
                    ┌───────────┴────────────┐
                    │                        │
                    ▼                        ▼
          ┌──────────────────┐       ┌─────────────┐
          │MemberMemberships │       │ Attendances │
          └────────┬─────────┘       └─────────────┘
                   │
                   ▼
          ┌──────────────────┐
          │ MembershipPlans  │
          └──────────────────┘


       Users
         │
         ▼
   TrainerProfiles


       Inquiries
           │
           ├──── InterestedPlan → MembershipPlans
           │
           └──── AssignedTo → Users