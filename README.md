# Clean Architecture with .NET 8

This repository demonstrates a Clean Architecture implementation using .NET 8, MongoDB, and Entity Framework Core. It provides a structured, maintainable, and testable foundation for building enterprise-level applications.

## Project Structure

The solution follows the principles of Clean Architecture with clear separation of concerns:

```
CleanArchitecture/
├── src/
│   ├── API/               # User interface & API endpoints
│   ├── Application/       # Business logic & use cases
│   ├── Core/              # Domain entities & business rules
│   └── Infrastructure/    # External concerns (database, file system, etc.)
```

### Core Layer

Contains all domain entities, enums, exceptions, interfaces, and logic specific to the domain:

- Domain Entities
- Domain Exceptions
- Interfaces
- Domain-specific operations

### Application Layer

Contains business logic and orchestrates the domain objects to perform tasks:

- Service Interfaces
- Service Implementations
- Business Logic
- Dependency Injection Configuration

### Infrastructure Layer

Contains implementations of interfaces defined in the application core:

- Data Persistence (MongoDB using Entity Framework Core)
- Repository Implementations
- External Service Implementations
- Infrastructure-specific Configuration

### API Layer

Contains API endpoints, controllers, middleware, and configuration:

- Controllers
- Middleware
- API Documentation (Swagger)
- Route Configuration

## Features

- **Clean Architecture**: Clear separation of concerns
- **MongoDB Integration**: Using MongoDB.EntityFrameworkCore
- **Repository Pattern**: Generic repository implementation with Unit of Work
- **RESTful API**: Standard HTTP methods for CRUD operations
- **Swagger Documentation**: API documentation with Swashbuckle
- **Dependency Injection**: Built-in .NET DI container
- **Entity Framework Core**: MongoDB provider for data access

## Technologies Used

- .NET 8
- MongoDB.EntityFrameworkCore 8.2.0
- Swashbuckle.AspNetCore 6.4.0
- Entity Framework Core

## Getting Started

### Prerequisites

- .NET 8 SDK
- MongoDB instance (local or Atlas)

### Setup

1. Clone the repository
   ```
   git clone https://github.com/yourusername/CleanArchitecture.git
   ```

2. Update the MongoDB connection string in `src/API/appsettings.json`
   ```json
   "MongoDB": {
     "ConnectionURI": "your-connection-string",
     "DatabaseName": "your-database-name"
   }
   ```

3. Build and run the solution
   ```
   dotnet build
   cd src/API
   dotnet run
   ```

4. Access Swagger UI at `https://localhost:7116/swagger`

## API Endpoints

The API provides the following endpoints for user management:

- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create a new user
- `PUT /api/users/{id}` - Update an existing user

## License

This project is licensed under the MIT License.

## Acknowledgments

This project structure is inspired by Jason Taylor's Clean Architecture template.
