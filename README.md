# User Action Recorder

A lightweight, high-precision tool to record and replay mouse and keyboard actions on Windows. Built with C# and Avalonia UI, featuring a modern interface and efficient performance.



## Features

- **Record Actions**: Captures mouse movements, clicks, scrolls, and key presses with high accuracy.
- **Accurate Replay**: Replays actions with drift compensation to ensure timing stays synchronized with the original recording.
- **Looping Options**:
  - **Fixed Iterations**: Set a specific number of times to repeat the macro.
  - **Infinite Replay**: Loop continuously until stopped.
- **Stop Hotkey**: Set a custom hotkey (default: `P`) to instantly stop any running replay.
- **Always on Top**: Checkbox to keep the tool visible above other windows.
- **Modern UI**: Clean and responsive interface using Avalonia UI.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (compatible with the project's target framework).
- Windows OS (currently targeted for `win-x64`).

### Running Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/Liqing1124/User-Action-Recorder.git
   ```
2. Navigate to the project directory:
   ```bash
   cd User-Action-Recorder
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## How to Publish

To create a standalone executable that doesn't require the user to have .NET installed, use the following command. This profile is optimized for a smaller file size (trimming and compression enabled).

```powershell
dotnet publish -c Release
```

The executable will be located in `bin/Release/net10.0-windows/win-x64/publish/`.

### Publish configuration details:
- **Single File**: The app and its dependencies are bundled into one `.exe`.
- **Self-Contained**: The .NET runtime is included, so no external installation is needed.
- **Trimmed**: Unused code is stripped out to reduce size.
- **Compressed**: The bundle is compressed to further save space.

## Usage Guide

1. **Recording**:
   - Click the **Record** button.
   - Perform the actions you want to automate.
   - Click **Stop** (the button toggles) when finished.

2. **Replaying**:
   - Set the **Repeat iterations** count or check **Infinite Replay**.
   - (Optional) Set a **Stop Hotkey** (e.g., `P` or `F1`).
   - Click **Replay**.
   - To stop the replay early, press your hotkey or click the **Stop Replay** button.

## License

This project is created for educational purposes. Feel free to modify and use it as needed.
