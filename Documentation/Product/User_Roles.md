# User Roles

## Admin
- Manages members, trainers, subscriptions, and reports.

## Member
- Views profile, attendance, and membership information.

## Trainer
- Manages assigned members and attendance records.
=========================================================
# GymPro - User Roles & Permissions

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Project: GymPro - Gym Management SaaS
Date: 2026

---

# 1. Purpose

This document defines the responsibilities, permissions, and system access for each user role within GymPro.

Role-Based Access Control (RBAC) ensures users can access only the features required for their responsibilities.

---

# 2. User Roles

The MVP supports six user roles.

1. Super Admin
2. Gym Owner
3. Manager
4. Receptionist
5. Trainer
6. Member

---

# 3. Super Admin

Description

The Super Admin manages the entire GymPro SaaS platform.

Responsibilities

- Register new gyms
- Activate or deactivate gyms
- Manage subscriptions
- Monitor system health
- View all tenants
- Configure global settings

Permissions

✅ Full System Access

---

# 4. Gym Owner

Description

The Gym Owner manages a single gym or multiple branches belonging to their organization.

Responsibilities

- Manage branches
- Manage staff
- View reports
- Manage memberships
- Manage trainers
- Manage payments

Permissions

✅ Dashboard

✅ Members

✅ Trainers

✅ Membership Plans

✅ Payments

✅ Attendance

✅ Reports

✅ Branch Management

❌ Cannot manage other gyms

---

# 5. Manager

Description

Responsible for daily gym operations.

Responsibilities

- Manage members
- Approve memberships
- Monitor attendance
- View reports

Permissions

✅ Members

✅ Memberships

✅ Attendance

✅ Payments

✅ Reports

❌ Cannot delete Gym

❌ Cannot manage subscriptions

---

# 6. Receptionist

Description

Handles customer interactions at the front desk.

Responsibilities

- Register members
- Record payments
- Mark attendance
- Renew memberships

Permissions

✅ Add Member

✅ Edit Member

✅ Record Payment

✅ Renew Membership

✅ Attendance

❌ Delete Payments

❌ Delete Members

❌ View Financial Reports

---

# 7. Trainer

Description

Responsible for member fitness programs.

Responsibilities

- View assigned members
- Assign workout plans
- Track PT sessions
- Create diet recommendations

Permissions

✅ Assigned Members

✅ Workout Plans

✅ PT Sessions

❌ Payments

❌ Reports

❌ Membership Plans

---

# 8. Member

Description

Gym customer.

Responsibilities

- View profile
- View membership
- View attendance
- View workout plans
- View payment history

Permissions

✅ Dashboard

✅ Attendance History

✅ Membership Details

✅ Workout Plan

✅ Payment History

❌ Edit Membership

❌ Manage Payments

❌ View Other Members

---

# 9. Permission Matrix

| Module | Super Admin | Owner | Manager | Receptionist | Trainer | Member |
|---------|------------|--------|----------|---------------|----------|----------|
| Dashboard | ✔ | ✔ | ✔ | ✔ | ✔ | ✔ |
| Gym | ✔ | ✔ | ✖ | ✖ | ✖ | ✖ |
| Branch | ✔ | ✔ | ✔ | ✖ | ✖ | ✖ |
| Members | ✔ | ✔ | ✔ | ✔ | Assigned Only | Own Only |
| Trainers | ✔ | ✔ | ✔ | View | Own Profile | ✖ |
| Membership | ✔ | ✔ | ✔ | ✔ | View | Own Only |
| Attendance | ✔ | ✔ | ✔ | ✔ | Assigned Members | Own Only |
| Payments | ✔ | ✔ | ✔ | Record Only | ✖ | View Only |
| Reports | ✔ | ✔ | Limited | ✖ | ✖ | ✖ |
| Settings | ✔ | ✔ | ✖ | ✖ | ✖ | ✖ |

---

# 10. Security Rules

- Users shall only access data belonging to their Gym.
- Members shall never view another member's data.
- Trainers shall only access assigned members.
- Receptionists cannot delete business data.
- Managers cannot manage subscriptions.
- Super Admin has unrestricted access.

---

# 11. Future Roles

The following roles may be introduced in future releases.

- Accountant
- Nutritionist
- HR Manager
- Marketing Executive
- Franchise Manager

---

# Document Status

Draft

Next Document

User Journey
