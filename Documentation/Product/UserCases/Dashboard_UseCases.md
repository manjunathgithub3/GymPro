# Dashboard Use Cases

Version: 1.0
Status: Draft
Project: GymPro

## Overview
This document outlines dashboard use cases for GymPro.

## Primary Actors
- Admin
- Branch Manager
- Staff

## Use Cases

### UC-DB-001: View Executive Dashboard
- Description: Admin views key business KPIs.

### UC-DB-002: View Daily Summary
- Description: User sees today’s attendance and revenue.

### UC-DB-003: View Pending Actions
- Description: User reviews expiring memberships and pending payments.

### UC-DB-004: Open Quick Actions
- Description: User accesses shortcuts for common tasks.
================================================================
# GymPro - Dashboard Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Dashboard

---

# Module Overview

The Dashboard provides users with a quick overview of important business information based on their assigned role. Dashboard widgets and statistics vary depending on the user's permissions.

---

# UC-DASH-001

## Title

View Dashboard

## Priority

P0

## Primary Actor

Gym Owner, Manager, Receptionist, Trainer

## Description

Displays the dashboard after successful login.

## Preconditions

- User is authenticated.

## Main Flow

1. User logs into GymPro.
2. System identifies the user's role.
3. Dashboard is loaded.
4. Relevant widgets are displayed.

## Postconditions

- Dashboard is displayed.

## API

GET /api/dashboard

---

# UC-DASH-002

## Title

View Today's Attendance

## Priority

P0

## Primary Actor

Gym Owner, Manager, Receptionist

## Description

Displays today's attendance summary.

## Preconditions

- Attendance records exist.

## Main Flow

1. Dashboard loads.
2. System calculates today's attendance.
3. Total attendance is displayed.

## API

GET /api/dashboard/today-attendance

---

# UC-DASH-003

## Title

View Active Members

## Priority

P0

## Primary Actor

Gym Owner, Manager

## Description

Displays the total number of active members.

## Preconditions

- Members exist.

## Main Flow

1. Dashboard loads.
2. System counts active members.
3. Count is displayed.

## API

GET /api/dashboard/active-members

---

# UC-DASH-004

## Title

View Today's Revenue

## Priority

P1

## Primary Actor

Gym Owner

## Description

Displays revenue collected for the current day.

## Preconditions

- Payments recorded.

## Main Flow

1. Dashboard loads.
2. System calculates today's revenue.
3. Revenue is displayed.

## API

GET /api/dashboard/today-revenue

---

# UC-DASH-005

## Title

View Expiring Memberships

## Priority

P0

## Primary Actor

Gym Owner, Manager, Receptionist

## Description

Displays memberships expiring within the configured reminder period.

## Preconditions

- Active memberships exist.

## Main Flow

1. Dashboard loads.
2. System checks expiry dates.
3. Expiring members list is displayed.

## API

GET /api/dashboard/expiring-memberships

---

# UC-DASH-006

## Title

View Pending Payments

## Priority

P1

## Primary Actor

Gym Owner, Manager

## Description

Displays members with pending or overdue payments.

## Preconditions

- Pending payments exist.

## Main Flow

1. Dashboard loads.
2. System retrieves pending payments.
3. Summary is displayed.

## API

GET /api/dashboard/pending-payments

---

# UC-DASH-007

## Title

Quick Actions

## Priority

P1

## Primary Actor

Receptionist, Manager

## Description

Provides shortcuts for frequently used actions.

## Available Actions

- Add Member
- Record Payment
- Renew Membership
- Mark Attendance
- Add Inquiry

## API

Not Applicable

---

# End of Dashboard Module