Author
Manjunath

# GymPro

A Production-Ready Gym Management System built using:

- ASP.NET Core 9
- Angular 20
- SQL Server
- Entity Framework Core
- Clean Architecture
- JWT Authentication

## Features

GymPro MVP
│
├── 1. Tenant / Gym Management
├── 2. Authentication & Authorization
├── 3. Member Management
├── 4. Membership Management
├── 5. Attendance
├── 6. Trainer Management
└── 7. Inquiry / Lead Management
Member 1 must never be visible to Gym B.
That's the heart of our multi-tenancy design.
===========================
User ≠ Member
A receptionist is a User.
A person who comes to the gym is a Member
==========================
Roles:
Initial roles:
SuperAdmin
GymOwner
Manager
Receptionist
Trainer
===========================
migration cmds: 
dotnet ef migrations add InitialCreate3 --project .\GymPro.Persistence --startup-project .\GymPro.API; dotnet ef database update --project .\GymPro.Persistence --startup-project .\GymPro.API