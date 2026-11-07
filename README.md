SmartInventory – Inventory Management System

A modern Inventory Management System built using ASP.NET Core MVC and Clean Architecture principles.

🚀 Project Overview

SmartInventory is an inventory management web application designed to manage inventory-related operations through a structured and maintainable architecture.

The project focuses on clean code, security, exception handling, and application logging.

🛠️ Technologies Used
ASP.NET Core MVC
C#
Entity Framework Core
SQL Server
Clean Architecture
ASP.NET Core Identity
JWT Authentication
Serilog Logging
Global Exception Handling
Razor Views
Bootstrap
✨ Features
Clean Architecture implementation
User Authentication
ASP.NET Core Identity integration
JWT Authentication
Global Exception Handling
Serilog Logging
MVC Dashboard
Razor Views
Responsive UI using Bootstrap
🏗️ Architecture

The project follows Clean Architecture principles to maintain separation of concerns.

Typical layers:

Domain: Core entities and business rules.
Application: Application logic and interfaces.
Infrastructure: Database and external service implementations.
Presentation: ASP.NET Core MVC application.
📂 Project Structure
text
SmartInventory
│
├── SmartInventory.Domain
├── SmartInventory.Application
├── SmartInventory.Infrastructure
├── SmartInventory.WebApi
│
└── README.md


Note: Adjust project names according to your actual solution structure.

⚙️ Getting Started
1. Clone Repository
bash
git clone YOUR_GITHUB_REPOSITORY_URL

2. Open Project

Open the solution file (.sln) in Visual Studio.

3. Configure Database

Update your database connection string in appsettings.json.

4. Apply Migrations
bash
dotnet ef database update

5. Run Application
bash
dotnet run

🔐 Security & Logging
Identity-based authentication.
JWT-based authentication support.
Centralized exception handling.
Structured logging using Serilog.
📸 Screenshots

Add your application screenshots here.

text
Screenshots/
├── Dashboard.png
├── Login.png
└── Products.png

🎯 Learning Objectives

This project demonstrates practical implementation of:

ASP.NET Core MVC
Clean Architecture
Authentication and Authorization concepts
Centralized Exception Handling
Application Logging
Separation of Concerns
👨‍💻 Author

Developed as a learning project to improve practical ASP.NET Core development skills.

📄 License

This project is available for educational purposes.
