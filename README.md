# BookApi

A simple .NET 8 Web API for managing a book collection with PostgreSQL/TimescaleDB as the database.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete books
- **RESTful API**: Standard REST endpoints for all operations
- **Scalar UI**: Interactive API documentation with Scalar
- **Serilog Logging**: Structured logging with ANSI color console output
- **TimescaleDB Support**: Uses PostgreSQL with TimescaleDB capabilities
- **Entity Framework Core**: Code-first approach with EF Core

## Setup Instructions

### 1. Database Setup

Before running the application, you need to set up the database in pgAdmin:

1. Open pgAdmin and connect to your PostgreSQL instance
2. Run the SQL script in `database_setup.sql`:
   - First, execute the `CREATE DATABASE bookapi;` command
   - Then connect to the `bookapi` database
   - Execute the rest of the script to create the table and sample data

### 2. Connection String

The connection string is already configured in `appsettings.json`:
```
Host=localhost;Port=5432;Database=bookapi;Username=admin;Password=admin123
```

Make sure this matches your PostgreSQL credentials.

### 3. Run the Application

```bash
dotnet restore
dotnet build
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000` (check your launchSettings.json for the exact ports).

**Scalar UI** will be available at `http://localhost:5288/scalar/v1` when running in Development mode.

## API Endpoints

### Get All Books
```
GET /api/books
```

### Get Book by ID
```
GET /api/books/{id}
```

### Create Book
```
POST /api/books
Content-Type: application/json

{
  "title": "Book Title",
  "author": "Author Name",
  "isbn": "978-1234567890",
  "publishedDate": "2023-01-01T00:00:00Z"
}
```

### Update Book
```
PUT /api/books/{id}
Content-Type: application/json

{
  "id": 1,
  "title": "Updated Title",
  "author": "Updated Author",
  "isbn": "978-0987654321",
  "publishedDate": "2023-02-01T00:00:00Z"
}
```

### Delete Book
```
DELETE /api/books/{id}
```

## Project Structure

```
BookApi/
├── Controllers/
│   └── BooksController.cs      # API endpoints
├── Data/
│   └── ApplicationDbContext.cs # EF Core DbContext
├── Models/
│   └── Book.cs                 # Book entity model
├── database_setup.sql          # SQL setup script for pgAdmin
├── Program.cs                  # Application entry point
└── appsettings.json           # Configuration including connection string
```

## Technologies

- .NET 10
- ASP.NET Core Web API
- Scalar AspNetCore (API Documentation)
- Serilog (Structured Logging)
- Entity Framework Core
- PostgreSQL with TimescaleDB
- Npgsql.EntityFrameworkCore.PostgreSQL

