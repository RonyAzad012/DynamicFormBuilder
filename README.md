# DynamicFormBuilder 
## Prerequisites

Before you begin, ensure you have the following installed and configured:

- **Visual Studio 2022** (or a compatible IDE/CLI)
- **.NET 8 SDK**
- **SQL Server** (Express Edition is free and sufficient)

> **Note:**  
> - Make sure SQL Server Authentication is set up, or Windows Authentication is configured correctly for your user.
> - You can download SQL Server Express from [Microsoft's official site](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/DynamicFormBuilder.git
   cd DynamicFormBuilder
   ```

2. **Open the solution:**
   - Open `DynamicFormBuilder.sln` in Visual Studio 2022.

3. **Configure the database connection:**
   - Update the connection string in `appsettings.json` to match your SQL Server instance and authentication method.

4. **Apply database migrations:**
   - Open the Package Manager Console in Visual Studio.
   - Run:
     ```powershell
     Update-Database
     ```
   - Alternatively, use the .NET CLI:
     ```bash
     dotnet ef database update
     ```

5. **Build and run the application:**
   - Press `F5` in Visual Studio, or run:
     ```bash
     dotnet run
     ```

6. **Access the application:**
   - Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console).

## Troubleshooting

- If you encounter SQL Server connection issues, verify your authentication settings and that SQL Server is running.
- For .NET SDK issues, ensure your `PATH` includes the .NET 8 SDK.

## Additional Resources

- [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Download SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022 Community Edition](https://visualstudio.microsoft.com/vs/community/)
