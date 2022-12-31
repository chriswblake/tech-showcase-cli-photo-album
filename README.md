## Showcase - ConsoleApp - PhotoAlbum

This is a simple C# console application to demonstrate making HTTP GET requests and usage of Unit Tests.

### Requirements
- .Net 6.0 [(download)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - (developed using SDK 6.0.404)

## Developer Notes
This project was developed using VS Code. There are pre-configured settings in the `.vscode` folder to use the built-in debug tools.

### Extenions
- C# by Microsoft [(ms-dotnettools.csharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- .NET Core Test Explorer [(formulahendry.dotnet-test-explorer)](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)


## How to Debug (using Visual Studio Code)
1. Within VS Code, on the left navigation bar, click the tab `Run and Debug`.
2. At the top, ensure `PhotosConsoleApp` is selected.
3. Press the green play icon.
    - VS Code will switch to the internal terminal view and start the program with debugging enabled.


## How to Build (Release)
From the root directory, run the following command:
```bash
dotnet build PhotosConsoleApp/PhotosConsoleApp.csproj --configuration Release
```

## How to Run (Release)
From the root directory, run the following command:
```bash
dotnet run --configuration Release --project PhotosConsoleApp/PhotosConsoleApp.csproj
```

Alternately, you can run the already built `.dll` directly.
```bash
dotnet PhotosConsoleApp/bin/Release/net6.0/PhotosConsoleApp.dll
```
