# Random Number Generator

A simple Windows Forms application that generates random numbers and saves them to a text file.

## Features

- Generate N random numbers (between 1000-2000)
- Save output to a custom file path
- File browser dialog for easy path selection
- Preview of generated numbers in the UI
- Input validation and error handling

## How to Use

1. **Enter Number Count**: Specify how many random numbers you want to generate
2. **Choose Output Path**: Enter a file path manually or click the `...` button to browse
3. **Click Generate**: The app will create the file and save the random numbers
4. **Preview**: See the first 10 generated numbers in the preview area

## Requirements

- .NET Framework 4.7.2 or higher
- Windows OS

## Building the Project

1. Open `RandomNumber_Gen.sln` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

## Project Structure

```
RandomNumber_Gen/
├── RandomNumber_Gen/
│   ├── Form1.cs              # Main form logic
│   ├── Form1.Designer.cs     # UI design code
│   ├── Program.cs            # Application entry point
│   └── RandomNumber_Gen.csproj
├── output/                   # Default output directory
└── README.md
```

## Learning Points

This beginner project demonstrates:
- Windows Forms UI development
- File I/O operations
- Input validation
- Exception handling
- Separation of concerns (business logic vs UI)
- Random number generation

## Future Enhancements

- Customizable min/max range for random numbers
- Multiple output formats (CSV, JSON)
- Statistics (average, min, max)
- Unit tests
- Progress bar for large generations