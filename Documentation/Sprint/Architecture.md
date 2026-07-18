📖 Before we code, let me explain why we have these projects.

This is the most important concept in the entire application.

GymPro.API

➡️ Receives HTTP Requests

GymPro.Application

➡️ Business Logic (Services, DTOs, Validators)

GymPro.Domain

➡️ Core Business Entities (Member, Trainer, Plan)

GymPro.Persistence

➡️ Database (EF Core, DbContext, Migrations)

GymPro.Infrastructure

➡️ External Services (Email, File Storage, JWT, Logging)

GymPro.Shared

➡️ Common Classes (Constants, Enums, Helpers, Responses)

===============================================================

GymPro
│
├── Backend
│   ├── GymPro.sln
│   │
│   ├── GymPro.API              --> Presentation Layer
│   ├── GymPro.Application      --> Business Logic
│   ├── GymPro.Contracts        --> DTOs & Contracts
│   ├── GymPro.Domain           --> Entities
│   ├── GymPro.Infrastructure   --> External Services
│   ├── GymPro.Persistence      --> EF Core
│   └── GymPro.Shared           --> Common Utilities
│
├── Frontend
├── Database
├── Documentation
└── Deployment
=========================================================
