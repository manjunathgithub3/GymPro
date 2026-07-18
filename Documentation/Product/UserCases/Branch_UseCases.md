# Branch Use Cases

Version: 1.0
Status: Draft
Project: GymPro

## Overview
This document defines branch management use cases for GymPro.

## Primary Actors
- Super Admin
- Branch Manager
- System

## Use Cases

### UC-BR-001: Add Branch
- Description: Create a new branch under an organization.

### UC-BR-002: Edit Branch
- Description: Update branch information and contact details.

### UC-BR-003: Disable Branch
- Description: Temporarily deactivate a branch.

### UC-BR-004: Search Branches
- Description: Search branches by name, city, or manager.
=========================================================
# GymPro - Branch Management Use Cases

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Module: Branch Management

---

# Module Overview

The Branch Management module allows Gym Owners to manage multiple gym branches under a single organization. Each member, trainer, payment, attendance record, and report belongs to a specific branch.

---

# UC-BR-001

## Title

Add Branch

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to add a new branch.

## Preconditions

- Gym Owner is logged in.
- Organization exists.

## Main Flow

1. Navigate to Branch Management.
2. Click Add Branch.
3. Enter branch details.
4. Save.
5. Branch is created successfully.

## Alternate Flow

- Branch name already exists.
- Required fields are missing.

## Postconditions

- New branch is created.

## API

POST /api/branches

---

# UC-BR-002

## Title

View Branch List

## Priority

P0

## Primary Actor

Gym Owner

## Description

Displays all branches belonging to the organization.

## Preconditions

- User is logged in.

## Main Flow

1. Open Branch Management.
2. System displays all branches.

## API

GET /api/branches

---

# UC-BR-003

## Title

View Branch Details

## Priority

P0

## Primary Actor

Gym Owner

## Description

Displays complete details of a selected branch.

## Preconditions

- Branch exists.

## Main Flow

1. Select branch.
2. View branch information.

## API

GET /api/branches/{id}

---

# UC-BR-004

## Title

Update Branch

## Priority

P0

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to edit branch information.

## Preconditions

- Branch exists.

## Main Flow

1. Open Edit Branch.
2. Update details.
3. Save.
4. Branch updated successfully.

## Alternate Flow

- Invalid data entered.

## API

PUT /api/branches/{id}

---

# UC-BR-005

## Title

Deactivate Branch

## Priority

P1

## Primary Actor

Gym Owner

## Description

Allows the Gym Owner to deactivate a branch without deleting historical data.

## Preconditions

- Branch exists.
- Branch has no active operations that prevent deactivation.

## Main Flow

1. Select branch.
2. Click Deactivate.
3. Confirm action.
4. Branch status changed to Inactive.

## Alternate Flow

- Branch already inactive.

## Postconditions

- Branch cannot be selected for new members or payments.

## API

PATCH /api/branches/{id}/deactivate

---

# UC-BR-006

## Title

Search Branch

## Priority

P1

## Primary Actor

Gym Owner

## Description

Allows users to search branches by name or location.

## Preconditions

- Branches exist.

## Main Flow

1. Enter search keyword.
2. System filters matching branches.

## API

GET /api/branches?search={keyword}

---

# End of Branch Management Module