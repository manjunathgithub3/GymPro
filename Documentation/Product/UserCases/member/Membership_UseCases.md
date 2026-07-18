# GymPro - Membership Management Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Membership Management

---

# Module Overview

The Membership Management module manages membership plans, purchases, renewals, freezes, cancellations, and membership status for gym members.

---

# UC-MSHIP-001

## Title

Create Membership Plan

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to create a membership plan.

## Preconditions

- User is logged in.

## Main Flow

1. Open Membership Plans.
2. Click Add Plan.
3. Enter plan details.
4. Save.

## API

POST /api/membership-plans

---

# UC-MSHIP-002

## Title

View Membership Plans

## Priority

P0

## Primary Actor

Receptionist, Gym Owner

## Description

Displays all active membership plans.

## API

GET /api/membership-plans

---

# UC-MSHIP-003

## Title

Update Membership Plan

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows updating an existing membership plan.

## API

PUT /api/membership-plans/{id}

---

# UC-MSHIP-004

## Title

Deactivate Membership Plan

## Priority

P1

## Primary Actor

Gym Owner

## Description

Marks a membership plan as inactive.

## API

PATCH /api/membership-plans/{id}/deactivate

---

# UC-MSHIP-005

## Title

Purchase Membership

## Priority

P0

## Primary Actor

Receptionist

## Description

Assigns a membership plan to a member.

## Preconditions

- Member exists.
- Membership plan exists.

## Main Flow

1. Select member.
2. Select membership plan.
3. Enter start date.
4. Calculate end date.
5. Save membership.
6. Redirect to payment.

## API

POST /api/memberships

---

# UC-MSHIP-006

## Title

Renew Membership

## Priority

P0

## Primary Actor

Receptionist

## Description

Renews an expired or active membership.

## Preconditions

- Member exists.

## Main Flow

1. Open member profile.
2. Click Renew Membership.
3. Select plan.
4. Save.
5. Redirect to payment.

## API

POST /api/memberships/{id}/renew

---

# UC-MSHIP-007

## Title

Freeze Membership

## Priority

P1

## Primary Actor

Manager

## Description

Temporarily pauses a membership.

## Preconditions

- Membership is active.

## Main Flow

1. Select membership.
2. Enter freeze period.
3. Save.

## API

PATCH /api/memberships/{id}/freeze

---

# UC-MSHIP-008

## Title

Resume Membership

## Priority

P1

## Primary Actor

Manager

## Description

Resumes a frozen membership.

## API

PATCH /api/memberships/{id}/resume

---

# UC-MSHIP-009

## Title

Cancel Membership

## Priority

P1

## Primary Actor

Manager

## Description

Cancels an active membership.

## API

PATCH /api/memberships/{id}/cancel

---

# UC-MSHIP-010

## Title

View Membership Details

## Priority

P0

## Primary Actor

Receptionist

## Description

Displays membership information.

## API

GET /api/memberships/{id}

---

# UC-MSHIP-011

## Title

View Membership History

## Priority

P1

## Primary Actor

Receptionist

## Description

Displays all memberships purchased by a member.

## API

GET /api/members/{id}/memberships

---

# UC-MSHIP-012

## Title

View Expiring Memberships

## Priority

P1

## Primary Actor

Receptionist, Gym Owner

## Description

Displays memberships that are nearing expiry.

## API

GET /api/memberships/expiring

---

# End of Membership Management Module