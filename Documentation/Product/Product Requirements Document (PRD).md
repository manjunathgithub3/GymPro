# GymPro - Product Requirements Document (PRD)

Version: 1.0 MVP
Status: Draft
Author: Manjunath CMR
Project: GymPro - Gym Management SaaS
Date: 2026

---

# 1. Product Vision

GymPro is a cloud-based SaaS platform that enables gym owners to manage their entire fitness business from a single application. The platform simplifies member management, memberships, attendance, trainers, payments, reports, and business operations while providing an excellent experience for both gym owners and members.

GymPro is designed to support both single-gym businesses and multi-branch organizations with a scalable, secure, and modern architecture.

---

# 2. Problem Statement

Many small and medium-sized gyms still rely on registers, Excel sheets, WhatsApp messages, and manual payment tracking.

These challenges include:

- Manual attendance tracking
- Missed membership renewals
- Poor payment tracking
- Lack of centralized member information
- No business analytics
- Difficulty managing multiple branches
- Limited communication with members

GymPro aims to solve these problems using a modern cloud-based solution.

---

# 3. Product Goals

The primary goals of GymPro MVP are:

- Digitize gym operations
- Reduce manual work
- Improve member experience
- Increase membership renewals
- Simplify payment tracking
- Provide business insights through dashboards and reports
- Build a scalable SaaS platform for future expansion

---

# 4. Target Customers

Primary Customers

- Small Gyms
- Medium-sized Fitness Centers
- Personal Training Studios
- CrossFit Centers
- Yoga Studios
- Multi-Branch Gym Chains

---

# 5. User Roles

The MVP will support the following roles:

1. Super Admin
2. Gym Owner
3. Manager
4. Receptionist
5. Trainer
6. Member

Each role will have role-based permissions.

---

# 6. MVP Features

## Authentication

- Secure Login
- JWT Authentication
- Forgot Password
- Change Password
- Role-Based Authorization

---

## Organization

- Gym Profile
- Branch Management
- Gym Settings

---

## Member Management

- Register Member
- Edit Member
- Upload Member Photo
- Emergency Contact
- Medical Information
- Search Members
- Active/Inactive Members

---

## Membership Management

- Membership Plans
- Purchase Membership
- Renew Membership
- Freeze Membership
- Membership Expiry Tracking

---

## Payment Management

- Cash Payments
- Card Payments
- UPI Payment Recording
- Partial Payments
- Pending Payments
- Payment History
- Invoice Generation (PDF)

---

## Attendance

- Manual Check-In
- QR Code Check-In
- Attendance History
- Attendance Reports

---

## Trainer Management

- Trainer Profile
- Assign Members
- PT Session Tracking

---

## Dashboard

- Total Members
- Active Members
- Expiring Memberships
- Today's Attendance
- Revenue Summary
- Pending Payments

---

## Reports

- Revenue Report
- Membership Report
- Attendance Report
- Payment Report

---

## Website

- Home
- About Us
- Membership Plans
- Contact Us
- Inquiry Form

---

# 7. Out of Scope (Not in MVP)

The following features will not be included in Version 1.0:

- Mobile Application
- AI Workout Generator
- AI Diet Generator
- Inventory Management
- Payroll Management
- WhatsApp Integration
- Online Payment Gateway Integration
- White Label Branding
- Advanced Analytics
- Biometric Device Integration

These features will be implemented in future releases.

---

# 8. Success Criteria

The MVP will be considered successful if it enables a gym to:

- Manage members digitally
- Track attendance efficiently
- Manage memberships
- Record payments
- Generate invoices
- View business reports
- Operate multiple branches
- Manage staff with role-based access

---

# 9. Future Roadmap

Version 1.1

- WhatsApp Notifications
- Birthday Greetings
- Inquiry Management
- Referral Management

Version 2.0

- Mobile App
- Online Payments
- Inventory
- Payroll
- GST Invoices

Version 3.0

- AI Workout Planner
- AI Diet Planner
- White Label Solution
- Business Intelligence Dashboard
- Predictive Analytics

---

# 10. Technology Stack

Frontend

- Angular

Backend

- ASP.NET Core Web API

Database

- SQL Server

ORM

- Entity Framework Core

Authentication

- JWT

Architecture

- Clean Architecture

Deployment

- Azure

Version Control

- Git & GitHub

---

# 11. Business Model

GymPro will be offered as a SaaS product.

Example Subscription Plans

Starter

- Single Branch
- Up to 300 Members

Professional

- Multiple Branches
- Unlimited Members

Enterprise

- White Label
- Advanced Features
- Custom Pricing

---

# Document Status

Draft

Next Review:
Software Requirements Specification (SRS)