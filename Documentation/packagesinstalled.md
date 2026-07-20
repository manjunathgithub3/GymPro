Install NuGet Packages

| Package                                                | Project                     | Why?                                                                 |
| ------------------------------------------------------ | --------------------------- | -------------------------------------------------------------------- |
| `Microsoft.AspNetCore.Authentication.JwtBearer`        | ✅ **GymPro.API**            | Authentication middleware runs in the API layer                      |
| `System.IdentityModel.Tokens.Jwt`                      | ✅ **GymPro.Infrastructure** | Used to generate and validate JWT tokens                             |
| `BCrypt.Net-Next`                                      | ✅ **GymPro.Infrastructure** | Password hashing implementation                                      |
| `Microsoft.Extensions.Options.ConfigurationExtensions` | ✅ **GymPro.API**            | Reads `JwtSettings` from `appsettings.json` (often already included) |
