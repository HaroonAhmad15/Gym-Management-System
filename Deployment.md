# Gym Management System — Deployment Guide

## System Requirements

- Operating System: Windows 7 SP1 or later (64-bit)
- .NET Framework: 4.7.2 or higher
- MySQL Server: 8.0 or higher
- RAM: Minimum 4 GB
- Storage: Minimum 500 MB free

## Step 1 — Install .NET Framework 4.7.2
1. Go to: https://dotnet.microsoft.com/download/dotnet-framework/net472
2. Download the Runtime installer
3. Run the installer and restart computer

## Step 2 — Install MySQL Server 8.0
1. Go to: https://dev.mysql.com/downloads/installer/
2. Download MySQL Installer
3. Run installer and choose "Developer Default"
4. Set root password to: gym123
5. Keep port as: 3306

## Step 3 — Create the Database
1. Open MySQL Workbench
2. Connect to localhost with root user
3. Go to File > Open SQL Script
4. Open the file: database.sql
5. Press Ctrl+Shift+Enter to execute
6. GymDB database will be created

## Step 4 — Configure Database Password
1. Open project in Visual Studio 2022
2. Find file: Database/DbConnection.cs
3. Change gym123 to your actual MySQL password

## Step 5 — Run the Project
1. Open Gym_Management_System.sln in Visual Studio
2. Press F5 to build and run

## Login Credentials
- Username: admin
- Password: admin123

## Troubleshooting
- "Unable to connect to MySQL": Check MySQL80 service is Running
- "Access denied for root": Check password in DbConnection.cs
- "Unknown database GymDB": Run database.sql script again
- NuGet package missing: Run: Install-Package MySql.Data -Version 9.7.0
