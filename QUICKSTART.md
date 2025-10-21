# Quick Start Guide

## Running the Application

### Option 1: Visual Studio (Recommended)
1. Open `ChristmasPoemApp.sln` in Visual Studio 2022
2. Press F5 to build and run
3. The application will open and the animation will start automatically

### Option 2: Command Line
```bash
# Navigate to the project directory
cd ashal_christmas_poem

# Build the project
dotnet build ChristmasPoemApp.csproj

# Run the application
dotnet run --project ChristmasPoemApp.csproj
```

### Option 3: Run Executable Directly
After building, you can run the executable directly:
```bash
# Navigate to output directory
cd bin/Debug/net9.0-windows

# Run the executable
./ChristmasPoemApp.exe
```

## What to Expect

When you run the application, you'll see:

1. **Window Opens**: A beautifully styled Christmas-themed window appears
2. **Snowflakes Fall**: White snowflakes gently fall in the background
3. **Quill Enters**: Santa's red quill pen floats in from the top
4. **Writing Begins**: The quill starts writing the poem character by character
5. **Quill Moves**: The quill follows along as the text appears
6. **Sparkle Effect**: A blue sparkle appears at the quill tip while writing
7. **Quill Exits**: When complete, the quill floats away upward

## First Time Setup

### Prerequisites
Ensure you have the following installed:
- Windows 10 or later
- .NET 9.0 SDK ([Download here](https://dotnet.microsoft.com/download/dotnet/9.0))

### Verify Installation
```bash
# Check .NET version
dotnet --version
```

You should see version 9.0 or later.

## Common Issues

### "Cannot find .NET runtime"
**Solution**: Install .NET 9.0 SDK from Microsoft's website

### "Build failed: NETSDK1100"
**Solution**: This project requires Windows. Ensure you're building on a Windows machine.

### "Application doesn't start"
**Solution**: 
1. Ensure all files are present
2. Try cleaning and rebuilding:
   ```bash
   dotnet clean
   dotnet build
   ```

## Customization

Want to personalize the poem? See [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md) for detailed customization instructions.

## Keyboard Shortcuts

- **Alt+F4**: Close the application
- **F11**: (If implemented) Toggle fullscreen

## Support

For issues or questions:
1. Check the [README.md](README.md) for detailed information
2. Review the [DEVELOPER_GUIDE.md](DEVELOPER_GUIDE.md) for technical details
3. Open an issue on the GitHub repository

## Enjoy!

Sit back and enjoy the magical animation of Santa's quill writing your Christmas message! 🎄✨
