# GymPro - Authentication Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Authentication

---

# Module Overview

The Authentication module secures the GymPro application by managing user authentication, authorization, password management, and user sessions.

---

# UC-AUTH-001

## Title

User Login

## Priority

P0

## Primary Actor

All Users

## Description

Allows a registered user to securely log into GymPro.

## Preconditions

- User account exists
- User account is active

## Main Flow

1. Open Login page.
2. Enter Email.
3. Enter Password.
4. Click Login.
5. System validates credentials.
6. JWT Access Token is generated.
7. Refresh Token is generated.
8. User is redirected to Dashboard.

## Alternate Flow

- Invalid email or password.
- User account is inactive.

## Postconditions

- User session is created.
- Login history is recorded.

## API

POST /api/auth/login

---

# UC-AUTH-002

## Title

User Logout

## Priority

P0

## Primary Actor

All Users

## Description

Allows a logged-in user to securely log out.

## Preconditions

- User is logged in.

## Main Flow

1. Click Logout.
2. Access Token is invalidated.
3. Refresh Token is revoked.
4. User is redirected to Login page.

## Postconditions

- Session terminated.

## API

POST /api/auth/logout

---

# UC-AUTH-003

## Title

Forgot Password

## Priority

P0

## Primary Actor

All Users

## Description

Allows users to request a password reset link.

## Preconditions

- Registered email exists.

## Main Flow

1. Click Forgot Password.
2. Enter Email.
3. Click Submit.
4. System sends reset link.
5. Success message displayed.

## Alternate Flow

- Email not found.

## API

POST /api/auth/forgot-password

---

# UC-AUTH-004

## Title

Reset Password

## Priority

P0

## Primary Actor

All Users

## Description

Allows users to reset their password using a secure token.

## Preconditions

- Valid reset token.
- Token not expired.

## Main Flow

1. Open Reset Password page.
2. Enter New Password.
3. Confirm Password.
4. Submit.
5. Password updated successfully.

## Alternate Flow

- Invalid token.
- Expired token.

## API

POST /api/auth/reset-password

---

# UC-AUTH-005

## Title

Change Password

## Priority

P0

## Primary Actor

Logged-in Users

## Description

Allows authenticated users to change their password.

## Preconditions

- User is logged in.

## Main Flow

1. Open Change Password page.
2. Enter Current Password.
3. Enter New Password.
4. Confirm Password.
5. Submit.
6. Password updated.

## Alternate Flow

- Current password incorrect.
- Password policy validation fails.

## API

POST /api/auth/change-password

---

# UC-AUTH-006

## Title

Refresh Access Token

## Priority

P0

## Primary Actor

Authenticated Users

## Description

Issues a new Access Token using a valid Refresh Token.

## Preconditions

- Refresh Token exists.
- Refresh Token is valid.

## Main Flow

1. Access Token expires.
2. Client sends Refresh Token.
3. System validates Refresh Token.
4. New Access Token issued.
5. New Refresh Token generated.

## Alternate Flow

- Refresh Token expired.
- Refresh Token revoked.

## API

POST /api/auth/refresh-token

---

# UC-AUTH-007

## Title

Get Current User Profile

## Priority

P1

## Primary Actor

Authenticated Users

## Description

Returns the profile information of the currently logged-in user.

## Preconditions

- User is authenticated.

## Main Flow

1. User opens Profile page.
2. System retrieves profile information.
3. Display profile.

## API

GET /api/auth/profile

---

# UC-AUTH-008

## Title

Role-Based Authorization

## Priority

P0

## Primary Actor

System

## Description

Restricts access to application features based on assigned user roles.

## Preconditions

- User authenticated.
- User role assigned.

## Main Flow

1. User requests protected resource.
2. System validates JWT.
3. System validates role.
4. Access granted or denied.

## Alternate Flow

- Invalid token.
- Insufficient permissions.

## API

Applied across all secured endpoints.

---

# End of Authentication Module