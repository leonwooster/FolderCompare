# Design Document: File Folder Sync

## Overview

The File Folder Sync application is a .NET Windows Forms desktop application that provides intelligent file synchronization between source and destination folders. The application focuses on safe file moving operations with conflict detection and resolution capabilities.

The system architecture follows a layered approach with clear separation between UI, business logic, and file system operations. The application uses Windows Forms for the user interface and .NET's built-in file system APIs for file operations.

## Architecture

The application follows a Model-View-Controller (MVC) pattern adapted for Windows Forms:

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Presentation  │    │  Business Logic │    │   Data Access   │
│     Layer       │    │     Layer       │    │     Layer       │
├─────────────────┤    ├─────────────────┤    ├─────────────────┤
│ • MainForm      │◄──►│ • FileComparer  │◄──►│ • FileSystem    │
│ • ConfirmDialog │    │ • MoveManager   │    │   Operations    │
│ • ProgressForm  │    │ • ConflictRes   │    │ • PathValidator │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

### Key Architectural Principles

1. **Separation of Concerns**: UI logic is separated from business logic and file operations
2. **Single Responsibility**: Each class has a focused, well-defined purpose
3. **Dependency Injection**: Business logic components are injected into UI components
4. **Event-Driven**: UI updates are driven by events from business logic operations

## Components and Interfaces

### Core Interfaces

```csharp
public interface IFileComparer
{
    ComparisonResult CompareFiles(string sourcePath, string destPath);
    List<FileConflict> FindConflicts(string sourceFolder, string destFolder);
}

public interface IMoveManager
{
    Task<MoveResult> MoveFileAsync(string sourcePath, string destPath, ConflictResolution resolution);
    Task<BatchMoveResult> MoveBatchAsync(List<FileMoveRequest> requests, bool skipConfirmation);
}

public interface ITimestampGenerator
{
    string GenerateTimestampSuffix();
    string ApplyTimestampToFilename(string originalPath, string timestamp);
}
```

### Core Components

#### FileComparer
Responsible for comparing files and detecting conflicts:
- Compares file sizes using FileInfo.Length
- Compares modification times using FileInfo.LastWriteTime
- Identifies files that exist in both locations
- Returns structured comparison results

#### MoveManager
Handles all file moving operations:
- Orchestrates file moves with conflict resolution
- Manages batch operations with progress reporting
- Integrates with TimestampGenerator for conflict resolution
- Provides rollback capabilities for failed operations

#### TimestampGenerator
Generates unique filenames for conflict resolution:
- Creates timestamp suffixes in YYYYMMDD_HHMMSS format
- Handles filename collision by adding counter suffixes
- Preserves file extensions correctly
- Validates Windows filename compatibility

#### ConflictResolver
Manages conflict resolution logic:
- Determines when user confirmation is needed
- Applies skip mode logic
- Tracks resolution decisions for batch operations

### UI Components

#### MainForm
Primary application window:
- Folder selection controls (source and destination)
- File list display with conflict indicators
- Operation controls (move selected, move all, skip mode toggle)
- Progress display and operation log

#### ConfirmationDialog
Modal dialog for conflict resolution:
- Side-by-side file information display
- Action buttons (Proceed, Skip, Cancel)
- File preview capabilities when possible

## Data Models

### Core Data Structures

```csharp
public class FileConflict
{
    public string FileName { get; set; }
    public FileInfo SourceFile { get; set; }
    public FileInfo DestinationFile { get; set; }
    public ConflictType Type { get; set; } // SizeDifference, TimeDifference, Both
}

public class ComparisonResult
{
    public bool FilesIdentical { get; set; }
    public bool SizesDiffer { get; set; }
    public bool TimesDiffer { get; set; }
    public long SourceSize { get; set; }
    public long DestSize { get; set; }
    public DateTime SourceModified { get; set; }
    public DateTime DestModified { get; set; }
}

public class MoveResult
{
    public bool Success { get; set; }
    public string OriginalPath { get; set; }
    public string FinalPath { get; set; }
    public string ErrorMessage { get; set; }
    public ConflictResolution ResolutionApplied { get; set; }
}

public enum ConflictResolution
{
    Overwrite,
    AppendTimestamp,
    Skip,
    Cancel
}
```

### File System Integration

The application uses .NET's FileInfo and DirectoryInfo classes for file system operations:
- FileInfo for file metadata (size, modification time)
- File.Move() for atomic file moving operations
- Path.Combine() for safe path construction
- Directory.EnumerateFiles() for folder scanning

## Correctness Properties

*A property is a characteristic or behavior that should hold true across all valid executions of a system-essentially, a formal statement about what the system should do. Properties serve as the bridge between human-readable specifications and machine-verifiable correctness guarantees.*

### Property 1: File Conflict Detection Accuracy
*For any* two folders with overlapping filenames, the conflict detection should correctly identify files as conflicting when they have different sizes OR different modification times, and identical when both size and modification time match.
**Validates: Requirements 2.1, 2.2, 2.3, 2.4, 2.5**

### Property 2: Timestamp Suffix Format Consistency  
*For any* filename and timestamp, the generated timestamped filename should follow the format "basename_YYYYMMDD_HHMMSS.extension" for files with extensions, and "basename_YYYYMMDD_HHMMSS" for files without extensions, while preserving the original extension exactly.
**Validates: Requirements 4.1, 4.2, 4.3, 4.6**

### Property 3: Filename Collision Resolution
*For any* filename that would create a collision after timestamp appending, the system should generate a unique filename by incrementing a counter suffix until no collision exists.
**Validates: Requirements 4.5**

### Property 4: Windows Filename Validity
*For any* generated filename (with timestamp and counter suffixes), the result should be a valid Windows filename that doesn't contain invalid characters or exceed path length limits.
**Validates: Requirements 4.4**

### Property 5: Move Operation Atomicity
*For any* file move operation, the file should either be successfully moved from source to destination (and no longer exist in source) or remain in the source location if the operation fails, but never exist in both locations simultaneously.
**Validates: Requirements 6.1**

### Property 6: Filename Preservation Rules
*For any* file being moved, if no conflict exists the original filename should be preserved exactly, and if a conflict exists and is resolved, the timestamped filename should be used in the destination.
**Validates: Requirements 6.2, 6.3**

### Property 7: Skip Mode Consistency
*For any* batch operation with skip mode enabled, all conflicts should be resolved automatically with timestamp suffixes without showing confirmation dialogs, and all resolutions should be logged.
**Validates: Requirements 5.2, 5.3**

### Property 8: Folder Content Identification
*For any* pair of source and destination folders, the system should correctly identify which files exist only in source, only in destination, or in both folders based on complete filename matching.
**Validates: Requirements 1.4, 1.5**

### Property 9: Error Handling Continuity
*For any* batch move operation where individual file moves fail, the operation should continue processing remaining files and report each failure without stopping the entire batch.
**Validates: Requirements 6.5**

### Property 10: Skip Operation File Preservation
*For any* file that is skipped during a move operation (either manually or due to errors), both the source and destination files should remain unchanged in their original locations.
**Validates: Requirements 3.6**

### Property 11: Edge Case Filename Handling
*For any* filename containing special characters, Unicode characters, very long names (approaching Windows path limits), or edge cases like files starting with dots, the system should handle them gracefully without corruption or failure.
**Validates: Requirements 4.4, 6.1**

### Property 12: Concurrent Access Protection
*For any* file operation, if the source or destination file is locked, in use, or being accessed by another process, the system should detect this condition and handle it gracefully with appropriate error reporting.
**Validates: Requirements 6.5**

### Property 13: Disk Space Validation
*For any* move operation, if insufficient disk space exists on the destination drive, the system should detect this condition before attempting the move and report the error without corrupting files.
**Validates: Requirements 6.5**

### Property 14: Path Length Boundary Handling
*For any* generated filename that would exceed Windows maximum path length (260 characters for legacy paths), the system should either truncate intelligently or report an error without attempting invalid operations.
**Validates: Requirements 4.4**

### Property 15: Network Drive Compatibility
*For any* source or destination folder located on network drives, UNC paths, or mapped drives, the file operations should work correctly with appropriate timeout and error handling for network issues.
**Validates: Requirements 6.1, 6.5**

## Error Handling

### Exception Management Strategy

1. **File System Exceptions**: Catch and wrap IOException, UnauthorizedAccessException, DirectoryNotFoundException
2. **User Input Validation**: Validate folder paths before operations
3. **Graceful Degradation**: Continue batch operations even if individual files fail
4. **User Feedback**: Provide clear error messages with actionable guidance
5. **Edge Case Handling**: 
   - **Long Paths**: Handle paths approaching Windows 260-character limit
   - **Special Characters**: Support Unicode and special characters in filenames
   - **Locked Files**: Detect and report files in use by other processes
   - **Network Issues**: Handle network drive timeouts and connectivity problems
   - **Disk Space**: Check available space before operations
   - **Permission Issues**: Handle read-only files and permission restrictions

### Logging and Monitoring

- Operation log displayed in UI showing all moves and conflicts resolved
- Error log for debugging purposes
- Progress tracking for long-running batch operations

## Testing Strategy

The application will use a dual testing approach combining unit tests and property-based tests to ensure correctness and reliability.

### Unit Testing Approach
- **Specific Examples**: Test concrete scenarios like moving a single file, handling specific conflict types
- **Edge Cases**: Test empty folders, files without extensions, very long filenames
- **Error Conditions**: Test permission errors, disk full scenarios, invalid paths
- **UI Integration**: Test form interactions and dialog workflows

### Property-Based Testing Approach
- **Universal Properties**: Test behaviors that should hold across all valid inputs
- **Comprehensive Coverage**: Use randomized inputs to discover edge cases
- **Minimum 100 iterations** per property test to ensure thorough validation
- **Framework**: Use FsCheck.NET for property-based testing in C#

Each property test will be tagged with: **Feature: file-folder-sync, Property {number}: {property_text}**

The testing strategy ensures both concrete correctness (unit tests) and universal correctness (property tests) for reliable file operations.