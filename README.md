# File Folder Sync

A .NET Windows Forms application that compares two folders and moves files with intelligent conflict resolution.

## Project Structure

```
FileFolderSync/
├── Models/                 # Data models and enums
│   ├── ConflictResolution.cs
│   ├── ConflictType.cs
│   ├── FileConflict.cs
│   ├── ComparisonResult.cs
│   ├── MoveResult.cs
│   ├── FileMoveRequest.cs
│   └── BatchMoveResult.cs
├── Services/              # Core business logic interfaces
│   ├── IFileComparer.cs
│   ├── IMoveManager.cs
│   └── ITimestampGenerator.cs
├── UI/                    # User interface components
│   └── MainForm.cs
├── Tests/                 # Test infrastructure
│   ├── PropertyTestBase.cs
│   └── SetupVerificationTests.cs
├── Program.cs             # Application entry point
└── TestRunner.cs          # Test execution helper
```

## Setup Verification

The project has been set up with:

✅ .NET 8.0 Windows Forms project structure  
✅ Core interfaces defined (IFileComparer, IMoveManager, ITimestampGenerator)  
✅ Data models and enums created  
✅ FsCheck.NET integrated for property-based testing  
✅ Basic project structure with Models, Services, UI folders  
✅ Placeholder MainForm for Windows Forms UI  

## Building and Running

```bash
# Build the project
dotnet build FileFolderSync.csproj

# Run the application
dotnet run --project FileFolderSync.csproj

# Run setup verification tests
dotnet run --project FileFolderSync.csproj -- --test
```

## Next Steps

The project is ready for implementation of the remaining tasks:
- Implement core data models and validation
- Create TimestampGenerator service
- Create FileComparer service  
- Create MoveManager service
- Build Windows Forms UI components
- Implement property-based tests

## Requirements Coverage

This setup addresses all foundational requirements by providing:
- Project structure for organized development
- Core interfaces that define the system architecture
- Data models that represent the domain concepts
- Testing infrastructure for property-based testing
- Basic UI framework for Windows Forms development