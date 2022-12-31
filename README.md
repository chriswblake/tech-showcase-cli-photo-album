## Showcase - ConsoleApp - PhotoAlbum

This is a simple C# console application to demonstrate making HTTP GET requests and usage of Unit Tests.

### Requirements
- .Net 6.0 [(download)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - (developed using SDK 6.0.404)

## Developer Notes
This project was developed using VS Code. There are pre-configured settings in the `.vscode` folder to use the built-in debug tools.

### Extenions
- C# by Microsoft [(ms-dotnettools.csharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- .NET Core Test Explorer [(formulahendry.dotnet-test-explorer)](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)

## Architecture
The application and its unit tests are separated into two folders.
- **PhotosConsoleApp** - The main program. 
- **PhotosConsoleAppTest** - Verifies the API calls and console interactions.

## How to Debug (using Visual Studio Code)
1. Within VS Code, on the left navigation bar, click the tab `Run and Debug`.
2. At the top, ensure `PhotosConsoleApp` is selected.
3. Press the green play icon.
    - VS Code will switch to the internal terminal view and start the program with debugging enabled.

## How to Test (using Visual Studio Code)
1. On the left navigation bar, click the tab `Testing`.
    - A list of all unit tests should be displayed.
1. Find the test with the same name as your method.
1. Press the play button.
    -VS Code will provide feedback about pass/fail.

## How to Test (using command line)
All tests for all modules
```bash
dotnet test PhotosConsoleAppTest/PhotosConsoleAppTest.csproj
```

All tests for a module
```bash
dotnet test PhotosConsoleAppTest/PhotosConsoleAppTest.csproj --filter "PhotosApiClientTest"
```

A single unit test
```bash
dotnet test PhotosConsoleAppTest/PhotosConsoleAppTest.csproj --filter "PhotosApiClientTest.Test_PhotosApiClientTest_Loads"
```

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

# Building a Standalone Executable
The following commands will build the project into a single file that can be distributed. Here are examples for MacOS and Windows. Below is documentation for targeting other operating systems and architectures.

> Ref: [Docs: donet publish](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish) - Publishes the application and its dependencies to a folder for deployment to a hosting system

> Ref: [Runtime Identifiers](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog) - NET packages to represent platform-specific assets.

## For MacOS
From the root directory, run the following command:
```bash
dotnet publish PhotosConsoleApp/PhotosConsoleApp.csproj --output "Standalone/osx-x64" --runtime osx-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained=true
```

## For Windows
```bash
dotnet publish PhotosConsoleApp/PhotosConsoleApp.csproj --output "Standalone/win-x64" --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained=true
```