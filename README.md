# Course Enrollment System

A Course Enrollment System built with ASP.NET Core MVC, Entity Framework Core, and In-Memory Database using n-tier architecture.

## Features

- **Student Management**: CRUD operations with email uniqueness, birthdate validation, and numeric validation for National ID/Phone
- **Course Management**: CRUD operations with capacity validation and server-side pagination
- **Enrollment Management**: Enroll students with duplicate prevention and full course validation
- **Dynamic UI**: jQuery-based available slots display, error auto-clearing, MVVM pattern demonstration

## Architecture

**N-Tier Architecture:**
- **Presentation Layer**: ASP.NET MVC Controllers, Views, ViewModels
- **Business Layer**: Services with Result pattern for error handling
- **Data Layer**: Entity Framework Core with Repositories

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code

## Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd CourseEnrollmentSystem
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build CourseEnrollmentSystem.sln
   ```

4. **Run the application**
   ```bash
   cd CourseEnrollmentSystem.Presentation
   dotnet run
   ```

5. **Access the application**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`
   - Sample data is automatically seeded on startup

## Project Structure

```
CourseEnrollmentSystem/
├── CourseEnrollmentSystem.Data/        # Data layer (Entities, Repositories, DbContext)
├── CourseEnrollmentSystem.Business/    # Business layer (Services, Results)
└── CourseEnrollmentSystem.Presentation/ # Presentation layer (Controllers, Views, ViewModels)
```

## Key Technologies

- .NET 8.0
- ASP.NET Core MVC
- Entity Framework Core 8.0.0 (In-Memory Database)
- jQuery & Bootstrap

## Design Patterns

- Repository Pattern
- Service Pattern
- Result Pattern (error handling)
- Dependency Injection
- MVVM Pattern (demonstration)

## Important Notes

- **In-Memory Database**: Data resets on application restart
- **Email Uniqueness**: Validated in service layer (In-Memory DB limitation)
- **Cascade Delete**: Implemented manually (In-Memory DB limitation)
- **Capacity Validation**: Prevents reducing capacity below current enrollments

## Testing

Key scenarios to test:
- Student CRUD with validation (email uniqueness, future birthdate, numeric fields)
- Course CRUD with capacity validation
- Enrollment creation (duplicate prevention, full course validation)
- Dynamic available slots feature
- Pagination functionality

---

**Built for educational/demonstration purposes**
