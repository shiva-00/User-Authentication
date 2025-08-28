# USER AUTHENTICATION SYSTEM (ASP.NET Core MVC) 

## Overview 

This Project is a User Authentication System built using ASP.NET Core MVC and Entity Framework Core.
It includes essential authentication features such as Registration, Login , Forgot Password and Otp Verification.
A TO-DO List with CRUD Operations will be added later.

## FEATURES 
- User Registration with Validation
- Secure Login
- Forgot Password with Otp Verification via Email
- Entity Framework Core with SQL Server for database management

## Tech Stack

- Backend: ASP.NET Core MVC
- Frontend: Razor Pages (HTML, CSS, Bootstrap)
- Database: SQL Server (Entity Framework Core)
- Authentication: Custom authentication with OTP verification

## Prerequisites
- .NET 6.0 SDK or later
- SQL Server (LocalDB or full version)
- Visual Studio / VS Code

## Folder Structure
 Controllers/        → Contains MVC Controllers
 Models/             → Entity Framework Models
 Views/              → Razor Pages for UI
 Data/               → DbContext and Database Configurations



# SetUp

1. ## **  Clone the Repository **
                  git clone https://github.com/your-username/your-repo-name.git
                  cd your-repo-name

2. ## ** Update Database Connection String **
                  Open appsettings.json and update the ConnectionStrings section with your SQL Server details.

3. ## ** Apply Migrations & Create Database **
                  dotnet ef database update

4. ## ** Run the Application**
                  dotnet run



# Future Enhancements
- Email Configuration for realtime Verification
- To-Do List with full CRUD operations
- Role-based Authentication (Admin/User)
- Profile Management




