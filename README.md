# Library Automation Web API

A .NET Core Web API project for library management system that handles book lending, user management, and administrative operations.

## Features

- User Management
  - Admin account registration and authentication
  - User account management
  - User identification with TC ID

- Book Management
  - Add, update, and delete books
  - Track book lending status
  - Book information includes name, author, and page count

- Lending System
  - Track book borrowing and returns
  - Manage lending periods
  - Monitor book availability status

## Technology Stack

- .NET Core
- Entity Framework Core
- SQL Server
- RESTful API architecture

## Database Schema

The system uses the following main entities:

- **AdminAccount**: Stores administrator credentials and information
- **UserAccount**: Manages library member information
- **Book**: Contains book details and availability status
- **BookUser**: Tracks book lending transactions

## Getting Started

### Prerequisites

- .NET Core SDK
- SQL Server
- Visual Studio / VS Code (or any preferred IDE)

### Configuration

1. Clone the repository
2. Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your_SQL_Server_Connection_String"
     }
   }
   ```
3. Run Entity Framework migrations:
   ```bash
   dotnet ef database update
   ```

### Running the Application

1. Navigate to the project directory
2. Run the following command:
   ```bash
   dotnet run
   ```
3. The API will be available at `https://localhost:5001` by default

## API Endpoints

The API provides endpoints for:
- Authentication and user management
- Book operations (CRUD)
- Lending management
- User account operations

## Development

This project uses:
- Entity Framework Core for database operations
- Built-in dependency injection
- Standard REST API practices
- CORS enabled for cross-origin requests

## License

This project is created for self-development purposes.
