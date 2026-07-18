# GymPro - Member Management Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Member Management

---

# Module Overview

The Member Management module enables gym staff to register, manage, search, and maintain member information. Every member belongs to an organization and a branch.

---

# UC-MEM-001

## Title

Register New Member

## Priority

P0

## Primary Actor

Receptionist

## Description

Allows staff to register a new gym member.

## Preconditions

- User is logged in.
- Membership plan exists.

## Main Flow

1. Click Add Member.
2. Enter member details.
3. Upload photo (optional).
4. Select membership plan.
5. Save member.
6. Member profile created.

## Alternate Flow

- Duplicate mobile number.
- Required fields missing.

## Postconditions

- Member is successfully created.

## API

POST /api/members

---

# UC-MEM-002

## Title

View Member Details

## Priority

P0

## Primary Actor

Receptionist, Manager, Gym Owner

## Description

Displays complete member information.

## Preconditions

- Member exists.

## Main Flow

1. Search member.
2. Open profile.
3. View complete details.

## API

GET /api/members/{id}

---

# UC-MEM-003

## Title

Update Member

## Priority

P0

## Primary Actor

Receptionist

## Description

Allows editing member information.

## Preconditions

- Member exists.

## Main Flow

1. Open profile.
2. Click Edit.
3. Update details.
4. Save.

## Alternate Flow

- Invalid mobile number.
- Duplicate mobile number.

## API

PUT /api/members/{id}

---

# UC-MEM-004

## Title

Search Members

## Priority

P0

## Primary Actor

Receptionist

## Description

Search members using name, phone number, membership ID or email.

## Preconditions

- Members exist.

## Main Flow

1. Enter search keyword.
2. Matching members displayed.

## API

GET /api/members?search=

---

# UC-MEM-005

## Title

View Member List

## Priority

P0

## Primary Actor

Receptionist

## Description

Displays paginated member list.

## API

GET /api/members

---

# UC-MEM-006

## Title

Deactivate Member

## Priority

P1

## Primary Actor

Manager

## Description

Marks a member as inactive without deleting historical records.

## Preconditions

- Member exists.

## Main Flow

1. Select member.
2. Click Deactivate.
3. Confirm.

## Postconditions

- Member status changed to Inactive.

## API

PATCH /api/members/{id}/deactivate

---

# UC-MEM-007

## Title

Reactivate Member

## Priority

P1

## Primary Actor

Manager

## Description

Reactivates an inactive member.

## API

PATCH /api/members/{id}/activate

---

# UC-MEM-008

## Title

Upload Member Photo

## Priority

P1

## Primary Actor

Receptionist

## Description

Uploads or updates member profile photo.

## API

POST /api/members/{id}/photo

---

# UC-MEM-009

## Title

Manage Emergency Contact

## Priority

P1

## Primary Actor

Receptionist

## Description

Stores emergency contact details.

## API

PUT /api/members/{id}/emergency-contact

---

# UC-MEM-010

## Title

Manage Medical Information

## Priority

P1

## Primary Actor

Receptionist

## Description

Stores allergies, injuries and medical conditions.

## API

PUT /api/members/{id}/medical-information

---

# UC-MEM-011

## Title

View Membership History

## Priority

P1

## Primary Actor

Receptionist

## Description

Displays all previous memberships purchased by the member.

## API

GET /api/members/{id}/membership-history

---

# UC-MEM-012

## Title

View Payment History

## Priority

P1

## Primary Actor

Receptionist

## Description

Displays all payments made by the member.

## API

GET /api/members/{id}/payment-history

---

# UC-MEM-013

## Title

View Attendance History

## Priority

P1

## Primary Actor

Receptionist, Trainer

## Description

Displays member attendance records.

## API

GET /api/members/{id}/attendance-history

---

# UC-MEM-014

## Title

Export Members

## Priority

P1

## Primary Actor

Gym Owner

## Description

Exports member list to Excel.

## API

GET /api/members/export

---

# UC-MEM-015

## Title

View Member Dashboard

## Priority

P1

## Primary Actor

Receptionist

## Description

Displays complete member summary including profile, membership, attendance and payment details.

## API

GET /api/members/{id}/dashboard

---

# End of Member Management Module