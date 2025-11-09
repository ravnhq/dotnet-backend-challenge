# .NET Backend Live Coding Challenge

This is a live coding exercise designed to assess .NET backend development skills.

## About This Project

This is a Student and Course Enrollment Management API built with **ASP.NET Core 9.0** and **Entity Framework Core**. The project uses SQLite for data persistence and includes Swagger/OpenAPI documentation for API exploration.

## Prerequisites

- .NET 9.0 SDK
- Your preferred IDE (Visual Studio, VS Code, or Rider)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd dotnet-backend-challenge
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access Swagger UI**
   - Navigate to: `https://localhost:7095/swagger` or `http://localhost:5198/swagger`
   - Explore the existing API endpoints

### Primary Objective

Implement a **POST /Students** endpoint to create a new student with the following requirements:

#### 1. Endpoint Implementation
- Create a POST endpoint at `/Students` that accepts student data

#### 2.	Request Validations and Error Handling
- Provide clear, structured error messages for validation failures

#### 4. Functionality
- Successfully persist the student to the database
- The endpoint should be fully functional and testable via Swagger UI

Good luck!
