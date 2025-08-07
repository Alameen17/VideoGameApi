# VideoGame API

A RESTful API built with .NET 9 and Entity Framework Core for managing video game data.

## Features

- **CRUD Operations** for video games
- **Entity Framework Core** with SQL Server
- **Database Migrations** 
- **API Documentation** with Scalar/OpenAPI
- **Development Environment** ready setup

## Technologies Used

- **.NET 9** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 9.0.7** - ORM for database operations
- **SQL Server Express** - Database engine
- **Scalar.AspNetCore** - API documentation UI
- **OpenAPI/Swagger** - API specification

## Prerequisites

Before running this application, make sure you have:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Alameen17/VideoGameApi.git
cd VideoGameApi
```

### 2. Configuration

The application uses the following connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS01;Database=VideoGameDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**Note:** Update the connection string to match your SQL Server instance name if different.

### 3. Database Setup

The database has already been migrated to SQL Server Management Studio (SSMS). If you need to recreate it:

```bash
# Install EF Core tools (if not already installed)
dotnet tool install --global dotnet-ef

# Create and apply migrations
dotnet ef migrations add Initial
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet restore
dotnet run
```

The API will be available at:
- **HTTP:** `http://localhost:5014`
- **API Documentation:** `http://localhost:5014/scalar/v1`

## API Endpoints

### Base URL: `http://localhost:5014`

| Method | Endpoint           | Description              |
|--------|--------------------|--------------------------|
| GET    | `/VideoGame`       | Get all video games      |
| GET    | `/VideoGame/{id}`  | Get video game by ID     |
| POST   | `/VideoGame`       | Create a new video game  |
| PUT    | `/VideoGame/{id}`  | Update a video game      |
| DELETE | `/VideoGame/{id}`  | Delete a video game      |

### Example API Calls

#### Get All Video Games
```http
GET /VideoGame
```

#### Get Video Game by ID
```http
GET /VideoGame/1
```

#### Create a New Video Game
```http
POST /VideoGame
Content-Type: application/json

{
    "title": "FC25",
    "platform": "Xbox 360",
    "developer": "EA Sports",
    "publisher": "Sony Interactive Entertainment"
  }
```

#### Update a Video Game
```http
PUT /VideoGame/1
Content-Type: application/json

  {
    "id": 2,
    "title": "Call of Duty",
    "platform": "PS5",
    "developer": "Activision",
    "publisher": "Playstation"
  }
```

#### Delete a Video Game
```http
DELETE /VideoGame/1
```

## Development

### Project Structure

```
VideoGameApi/
├── Controllers/
│   ├── VideoGameController.cs
│   └── WeatherForecastController.cs
├── Data/
│   └── VideoGameDbContext.cs
├── Models/
│   └── VideoGame.cs
├── Migrations/
│   └── [EF Core Migration Files]
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── VideoGameApi.csproj
```

### Adding New Migrations

When you modify the data models:

```bash
# Add a new migration
dotnet ef migrations add [MigrationName]

# Update the database
dotnet ef database update
```

### Package Dependencies

Key NuGet packages used:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.7" />
<PackageReference Include="Scalar.AspNetCore" Version="1.0.0" />
```

## Database Connection

The application connects to:
- **Server:** `localhost\SQLEXPRESS01`
- **Database:** `VideoGameDb`
- **Authentication:** Windows Authentication (Trusted Connection)

You can view and manage the database using SQL Server Management Studio (SSMS).

## API Documentation

Interactive API documentation is available at:
- **Scalar UI:** `http://localhost:5014/scalar/v1`
- **OpenAPI JSON:** `http://localhost:5014/openapi/v1.json`

## Troubleshooting

### Common Issues

1. **Database Connection Error**
   - Verify SQL Server Express is running
   - Check the connection string matches your SQL Server instance name
   - Ensure Windows Authentication is enabled

2. **Migration Issues**
   ```bash
   # Reset database (removes all data)
   dotnet ef database drop
   dotnet ef database update
   ```

3. **Port Already in Use**
   - Change the port in `Properties/launchSettings.json`
   - Or kill the process using the port

4. **API Documentation Not Loading**
   - Ensure you're running in Development environment
   - Check that Scalar package is installed
   - Try accessing `/openapi/v1.json` first

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add/update tests if necessary
5. Submit a pull request

## License

This project is licensed under the MIT License.

## Contact

- **Developer:** Alameen
- **GitHub:** [@Alameen17](https://github.com/Alameen17)
- **Repository:** [VideoGameApi](https://github.com/Alameen17/VideoGameApi)
