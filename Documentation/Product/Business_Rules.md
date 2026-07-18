# Business Rules

## Membership Rules
- Memberships must be linked to a valid member profile.
- Attendance must be recorded for active members only.

## Payment Rules
- Payments must be associated with a valid membership or invoice.
- Duplicate payments should be prevented where applicable.
================================
# GymPro - Business Rules

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Project: GymPro - Gym Management SaaS
Date: 2026

---

# Document Information

| Version | Date | Author | Status |
|----------|------|--------|--------|
| 1.0 | 2026 | Manjunath CMR | Draft |

---

# 1. Introduction

This document defines the business rules that govern the GymPro application. These rules ensure that all business operations remain consistent, secure, and compliant with business requirements.

Business Rules are mandatory validations that must always be enforced by the application.

---

# 2. Gym Rules

## BR-001

A Gym must have a unique name.

---

## BR-002

Each Gym must have at least one active Branch.

---

## BR-003

A Branch cannot exist without a Gym.

---

## BR-004

A deleted Gym cannot be restored without Super Admin approval.

---

# 3. User Rules

## BR-005

Every User must belong to exactly one Gym.

---

## BR-006

Every User must have exactly one active Role.

---

## BR-007

A User email address must be unique within the application.

---

## BR-008

Inactive Users cannot log in.

---

## BR-009

Passwords must be stored using secure hashing algorithms.

---

# 4. Member Rules

## BR-010

Every Member must belong to exactly one Gym.

---

## BR-011

Every Member must belong to one Branch.

---

## BR-012

A Member mobile number must be unique within the same Gym.

---

## BR-013

A Member cannot have multiple active memberships at the same time.

---

## BR-014

A Member may have multiple historical memberships.

---

## BR-015

Emergency Contact information is optional.

---

## BR-016

Medical Information is optional but recommended.

---

## BR-017

Inactive Members cannot mark attendance.

---

# 5. Membership Rules

## BR-018

Membership Start Date cannot be greater than End Date.

---

## BR-019

Membership Expiry Date shall be calculated automatically.

---

## BR-020

Only Active Memberships allow attendance.

---

## BR-021

Frozen Memberships cannot be renewed until reactivated.

---

## BR-022

Expired Memberships cannot be used for attendance.

---

## BR-023

Membership Plans cannot be deleted if members are currently subscribed.

---

# 6. Payment Rules

## BR-024

Every Payment must belong to a Membership.

---

## BR-025

Payment Amount cannot be negative.

---

## BR-026

Partial Payments are allowed.

---

## BR-027

Outstanding Balance cannot become negative.

---

## BR-028

Invoices must be generated for every successful payment.

---

## BR-029

Deleted Payments cannot be modified.

---

# 7. Attendance Rules

## BR-030

Attendance can only be marked once per member per day.

---

## BR-031

Attendance requires an Active Membership.

---

## BR-032

Attendance shall store Check-In time.

---

## BR-033

Future attendance records cannot be created.

---

# 8. Trainer Rules

## BR-034

Every Trainer belongs to one Gym.

---

## BR-035

A Trainer may manage multiple Members.

---

## BR-036

PT Sessions cannot become negative.

---

# 9. Authorization Rules

## BR-037

Only Super Admin can create a Gym.

---

## BR-038

Gym Owners can manage only their own Gym.

---

## BR-039

Managers cannot delete Gyms.

---

## BR-040

Receptionists cannot modify payment history.

---

## BR-041

Trainers can only access assigned Members.

---

## BR-042

Members can only access their own information.

---

# 10. Audit Rules

## BR-043

All login attempts shall be logged.

---

## BR-044

Critical business operations shall be recorded in Audit Logs.

Examples:

- Member Created
- Membership Renewed
- Payment Received
- Attendance Marked
- Trainer Assigned

---

# 11. Multi-Tenant Rules

## BR-045

Every business entity shall belong to exactly one Gym.

---

## BR-046

Users shall never access another Gym's data.

---

## BR-047

Reports shall display only data belonging to the logged-in Gym.

---

# 12. Soft Delete Rules

## BR-048

Business entities shall use Soft Delete instead of permanent deletion.

---

## BR-049

Soft Deleted records shall not appear in application searches.

---

## BR-050

Only Super Admin may permanently delete records.

---

# 13. Future Rules

The following rules will be implemented in future releases:

- WhatsApp Notifications
- AI Recommendations
- Payroll Rules
- Inventory Rules
- Mobile Application Rules

---

# Document Status

Draft

Next Document:

User Roles & Permissions
