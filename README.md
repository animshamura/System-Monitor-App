# System Monitor App

A lightweight Windows desktop application built with C# and WinForms for monitoring system performance and managing running processes.

## Features

- Displays real-time CPU usage
- Shows available RAM in MB
- Lists active processes with memory consumption
- Filters processes by name using a search box
- Refreshes the process list on demand
- Ends a selected process with confirmation

## Tech Stack

- C#
- .NET 10
- Windows Forms (WinForms)
- PerformanceCounter for system telemetry

## Project Structure

```text
SystemMonitorApp/
├── Form1.cs
├── Form1.Designer.cs
├── ProcessModel.cs
├── Program.cs
├── SystemMonitorApp.csproj
├── .gitignore
├── README.md
└── bin/
└── obj/
```

## Prerequisites

Before running the app, make sure you have:

- Windows 10 or later
- .NET 10 SDK
- Visual Studio 2022 or newer, or another .NET-compatible editor

## Run the App

### Using Visual Studio

1. Open the solution/project in Visual Studio.
2. Set the startup project to `SystemMonitorApp`.
3. Press `F5` to run.

### Using the .NET CLI

From the project folder:

```bash
dotnet restore
dotnet build
dotnet run
```

## Notes

- This app targets Windows, so it is intended to run on Windows only.
- The CPU and memory telemetry values are read using Windows performance counters.
- Process termination requires permission to kill the selected process.

## License

This project is provided as-is for educational and personal use.

## Contributing

Pull requests and improvements are welcome. To contribute:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a pull request
