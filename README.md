# System Monitor App

<p align="center">
  <img src="https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/Platform-Windows-0078D6?logo=microsoft&logoColor=white" alt="Windows" />
  <img src="https://img.shields.io/badge/Language-C%23-239120?logo=csharp&logoColor=white" alt="C#" />
</p>

A Windows desktop utility for monitoring live system usage and managing running processes. The app shows CPU and memory telemetry, lists active tasks, lets users filter entries by name, and allows terminating a selected process with confirmation.

## Features

- Real-time CPU usage display
- Available RAM monitoring
- Active process list with memory usage
- Search/filter by process name
- Manual refresh of process data
- End task action with confirmation prompt
- Built with WinForms and .NET 10

## Screenshots

> Add screenshots here later to showcase the interface.

## Requirements

- Windows 10 or later
- .NET 10 SDK
- Visual Studio 2022 or newer, or any compatible .NET development environment

## Installation

### Option 1: Visual Studio

1. Open the project in Visual Studio.
2. Restore NuGet packages.
3. Set the startup project to `SystemMonitorApp`.
4. Press `F5` to run the application.

### Option 2: Command Line

```bash
dotnet restore
dotnet build
dotnet run
```

## Project Structure

```text
SystemMonitorApp/
├── src/
│   └── SystemMonitorApp/
│       ├── Program.cs
│       ├── Form1.cs
│       ├── Form1.Designer.cs
│       └── ProcessModel.cs
├── tests/
│   └── SystemMonitorApp.Tests/
├── docs/
├── assets/
├── .gitignore
├── .gitattributes
├── LICENSE
├── README.md
├── SystemMonitorApp.csproj
├── SystemMonitorApp.csproj.user
├── bin/
├── obj/
└── .vs/
```

## How It Works

The app uses Windows Performance Counters to read system telemetry and enumerates current processes using the .NET process API. Each process is mapped to a lightweight model that includes the process ID, name, and memory footprint.

## Notes

- This is a Windows-only application.
- Killing a process requires sufficient permissions.
- Performance counters may briefly delay or return stale values until initialized.

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a pull request

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
