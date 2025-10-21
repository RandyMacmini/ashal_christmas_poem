# Floating Pen Christmas Poem - WPF Application

A beautiful WPF desktop application featuring an animated Santa's quill that gracefully writes a heartfelt Christmas poem. Perfect for sending warm holiday wishes to loved ones who are far away.

## Features

- **Animated Santa's Quill**: Watch as Santa's magical quill floats in and writes the poem character by character
- **Beautiful Christmas Theme**: Rich festive colors with a vintage parchment background
- **Smooth Animations**: 
  - Quill floating and gentle rotation effects
  - Ink sparkle effect at the writing tip
  - Falling snowflakes in the background
  - Graceful entry and exit animations
- **Heartfelt Poem**: A touching Christmas message about missing loved ones during the holidays

## Requirements

- Windows Operating System
- .NET 9.0 or later
- Visual Studio 2022 or later (recommended for development)

## Building the Application

### Using Visual Studio
1. Open `ChristmasPoemApp.sln` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

### Using Command Line
```bash
# Build the application
dotnet build ChristmasPoemApp.csproj

# Run the application
dotnet run --project ChristmasPoemApp.csproj
```

## Project Structure

```
ashal_christmas_poem/
├── ChristmasPoemApp.sln          # Visual Studio solution file
├── ChristmasPoemApp.csproj       # Project file
├── App.xaml                       # Application XAML
├── App.xaml.cs                    # Application code-behind
├── MainWindow.xaml                # Main window UI definition
├── MainWindow.xaml.cs             # Main window logic and animations
├── .gitignore                     # Git ignore file
└── README.md                      # This file
```

## Technical Details

### Technologies Used
- **WPF (Windows Presentation Foundation)**: For rich desktop UI
- **XAML**: For declarative UI design
- **C# 12**: For application logic
- **.NET 9.0**: Latest .NET framework

### Animation Highlights

1. **Typing Animation**: The poem is revealed character by character with smooth timing
2. **Quill Movement**: The quill pen follows the text as it's being written
3. **Floating Effect**: Subtle up-and-down and rotation animations create a magical floating effect
4. **Ink Sparkle**: Visual feedback at the quill tip when writing each character
5. **Snowfall**: Multiple animated snowflakes create a winter atmosphere

### Customization

You can easily customize the application:

- **Poem Text**: Edit the `poemLines` array in `MainWindow.xaml.cs`
- **Colors**: Modify the color values in `MainWindow.xaml`
- **Animation Speed**: Adjust the timer interval in `MainWindow.xaml.cs` (currently 50ms)
- **Quill Design**: Modify the Path and Polygon elements in the XAML

## The Poem

```
Missing you this Christmas time,
While on vacation, far away,
Though miles apart, you're in my heart,
Each moment, every single day.

The twinkling lights and falling snow,
Remind me of your loving smile,
And though we're separated now,
I'll hold you close in just a while.

So here's a message from my soul,
Wrapped in festive cheer so bright,
Merry Christmas, dear one true,
May your holidays be filled with light!

With all my love,
- Santa's Quill
```

## Screenshots

When you run the application, you'll see:
- A beautifully styled parchment-like canvas
- An animated red quill pen with gold tip
- The poem being written in elegant script font
- Falling snowflakes creating a winter atmosphere
- Holly berry decorations in the corners

## License

This project is open source and available for personal and commercial use.

## Credits

Created with ❤️ for spreading holiday cheer and sending warm wishes to loved ones during the Christmas season.
