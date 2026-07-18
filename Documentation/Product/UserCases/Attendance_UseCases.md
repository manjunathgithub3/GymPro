# GymPro - Attendance Use Cases

Version: 1.0 MVP
Module: Attendance

---

## UC-ATT-001

Title: Member Check-In

Priority: P0

Actor: Receptionist

Description:
Marks member attendance.

Main Flow

1. Search member.
2. Verify active membership.
3. Click Check-In.
4. Attendance recorded.

API

POST /api/attendance/check-in

---

## UC-ATT-002

Title: View Today's Attendance

Priority: P0

Actor: Receptionist

Description:
Displays today's attendance.

API

GET /api/attendance/today

---

## UC-ATT-003

Title: Attendance History

Priority: P1

Actor: Receptionist

Description:
Displays attendance history of a member.

API

GET /api/attendance/member/{id}

---

## UC-ATT-004

Title: Attendance Report

Priority: P1

Actor: Gym Owner

Description:
Displays attendance report by date.

API

GET /api/attendance/report