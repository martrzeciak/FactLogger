# FactLogger

This application is a .NET-based Blazor app designed to fetch random cat facts from an API and log them into a text file. It uses:  
1. Blazor for building the interactive UI, where users can click a button to get a new cat fact.
2. Dependency Injection for managing services like `CatFactService` and `TextFileService`.
3. HttpClient for making API calls to fetch cat facts.
4. Logging through `ILogger` to handle application logs.
5. File I/O for saving the fetched facts in a local text file.
6. Configuration via `IConfiguration` to set the API's base URL.

## Folder structure
- `Components/Pages/Home.razor`: The main Blazor page displaying the random cat facts.
- `Configuration/ApiSettings.cs`: Defines configuration for the API base URL.
- `Contracts/ICatFactService.cs`: Interface for fetching cat facts from the API.
- `Contracts/ITextFileService.cs`: Interface for logging facts to a file.
- `Models/CatFact.cs`: Represents the structure of a cat fact object (fact and length).
- `Services/CatFactService.cs`: Handles API calls to fetch cat facts.
- `Services/TextFileService.cs`: Handles writing cat facts to a text file.
- `Extensions/ApplicationServiceExtensions.cs`: Configures dependency injection for services and HTTP clients.
- `Program.cs`: Configures the app, including dependency injection and middleware.
- `appsettings.json`: Stores API configuration like BaseUrl.
- `cat_facts.txt`: The output file for logged cat facts (generated during runtime).
