# FinanceBlazor-.NET

This project is a comprehensive finance management application enabling users to register, log in, and manage financial portfolios. It leverages Blazor for a dynamic frontend experience and .NET 7 for a robust backend, incorporating JWT for secure authentication and Entity Framework Core for efficient data handling.

## Features
- User Registration and Login: Secure JWT authentication.
- Financial Portfolio Management: Users can add and track selected companies.
- Real-time Financial Data: Display and manage real-time financial data including stock prices and trends.
- Secure Endpoints: Ensuring user-specific data access and protection.
## Technologies
- Frontend: Blazor WebAssembly
- Backend: .NET 7, ASP.NET Core Web API
- Database: SQL Server
 - Authentication: JWT
## Getting Started
- .NET 7 SDK
- SQL Server
- A modern web browser supporting WebAssembly
# Setting Up the Database
- Create a new SQL Server database.
- Update the appsettings.json in the API project with your database connection string under the DefaultConnection key.
## Running the Project
- Backend: Navigate to the API project directory and run dotnet run.
- Frontend: Navigate to the Blazor project directory and run dotnet run.
Ensure both projects are running for the application to function properly.
