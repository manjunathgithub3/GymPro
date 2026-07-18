# Organization Use Cases

Version: 1.0
Status: Draft
Project: GymPro

## Overview
This document defines organization-level use cases for GymPro.

## Primary Actors
- Super Admin
- Gym Owner
- System

## Use Cases

### UC-ORG-001: Register Gym
- Description: A new gym organization registers on the platform.

### UC-ORG-002: Update Organization Profile
- Description: Gym owner updates business details and branding.

### UC-ORG-003: Configure Organization Settings
- Description: Owner configures timezone, currency, and notification settings.

### UC-ORG-004: View Subscription Status
- Description: Owner checks the current subscription plan and billing state.==============
======================================
# GymPro - Organization Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Organization

---

# Module Overview

The Organization module allows the Super Admin and Gym Owner to manage gym information and application settings.

---

# UC-ORG-001

## Title

Register Gym

## Priority

P0

## Primary Actor

Super Admin

## Description

Allows the Super Admin to register a new gym in the GymPro platform.

## Preconditions

- Super Admin is logged in.

## Main Flow

1. Open Add Gym page.
2. Enter gym details.
3. Enter owner details.
4. Save.
5. Gym is created.
6. Owner account is created.

## Alternate Flow

- Gym name already exists.
- Required fields are missing.

## Postconditions

- Gym is registered.
- Owner receives login credentials.

## API

POST /api/organizations

---

# UC-ORG-002

## Title

View Organization Details

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to view organization details.

## Preconditions

- User is logged in.

## Main Flow

1. Open Organization page.
2. System displays organization information.

## API

GET /api/organizations/{id}

---

# UC-ORG-003

## Title

Update Organization Details

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to update organization information.

## Preconditions

- User is logged in.

## Main Flow

1. Open Edit Organization.
2. Update details.
3. Save.
4. Organization information is updated.

## Alternate Flow

- Invalid data entered.

## API

PUT /api/organizations/{id}

---

# UC-ORG-004

## Title

Upload Organization Logo

## Priority

P1

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to upload or change the gym logo.

## Preconditions

- Organization exists.

## Main Flow

1. Open Organization Settings.
2. Click Upload Logo.
3. Select image.
4. Save.
5. Logo is updated.

## Alternate Flow

- Invalid image format.
- File size exceeds limit.

## API

POST /api/organizations/{id}/logo

---

# UC-ORG-005

## Title

View Subscription Information

## Priority

P1

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to view the current subscription plan and expiry date.

## Preconditions

- User is logged in.

## Main Flow

1. Open Subscription page.
2. View plan details.
3. View expiry date.

## API

GET /api/subscriptions/current

---

# End of Organization Module