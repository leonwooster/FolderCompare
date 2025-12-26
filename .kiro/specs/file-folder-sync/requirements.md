# Requirements Document

## Introduction

A .NET Windows Forms application that compares two folders (source and destination) and moves files from source to destination with intelligent conflict resolution. The system handles file name conflicts by comparing file size and modification timestamps, prompting for user confirmation when differences are detected, and optionally appending timestamps to prevent overwrites.

## Glossary

- **Source_Folder**: The directory containing files to be moved
- **Destination_Folder**: The directory where files will be moved to
- **File_Conflict**: When a file with the same name exists in both source and destination folders
- **File_Comparison**: Process of checking file size and modification timestamp between source and destination files
- **Timestamp_Suffix**: A date/time string appended to filename to make it unique
- **Skip_Mode**: User option to bypass conflict confirmation prompts during batch operations
- **Move_Operation**: The process of transferring a file from source to destination folder

## Requirements

### Requirement 1: Folder Selection and Comparison

**User Story:** As a user, I want to select source and destination folders, so that I can compare their contents before moving files.

#### Acceptance Criteria

1. THE Application SHALL provide a user interface to select the source folder
2. THE Application SHALL provide a user interface to select the destination folder
3. WHEN both folders are selected, THE Application SHALL scan and display the contents of both folders
4. THE Application SHALL identify files that exist in the source folder but not in the destination folder
5. THE Application SHALL identify files that exist in both folders with potential conflicts

### Requirement 2: File Conflict Detection

**User Story:** As a user, I want the system to detect file conflicts based on size and modification time, so that I can avoid accidentally overwriting different files with the same name.

#### Acceptance Criteria

1. WHEN a file exists in both source and destination folders with the same name and extension, THE File_Comparison SHALL compare file sizes
2. WHEN a file exists in both source and destination folders with the same name and extension, THE File_Comparison SHALL compare modification timestamps
3. IF file sizes are different OR modification timestamps are different, THEN THE Application SHALL mark the file as having a conflict
4. IF file sizes are identical AND modification timestamps are identical, THEN THE Application SHALL treat the files as identical
5. THE Application SHALL compare files based on complete filename including extension
6. THE Application SHALL display conflict status clearly in the user interface

### Requirement 3: Conflict Resolution with User Confirmation

**User Story:** As a user, I want to be prompted when file conflicts are detected, so that I can decide how to handle each conflict appropriately.

#### Acceptance Criteria

1. WHEN a file conflict is detected during move operation, THE Application SHALL display a confirmation dialog
2. THE Confirmation_Dialog SHALL show source file details (size, modification date)
3. THE Confirmation_Dialog SHALL show destination file details (size, modification date)
4. THE Confirmation_Dialog SHALL provide options to proceed with move, skip the file, or cancel the operation
5. WHEN the user confirms to proceed, THE Application SHALL append a timestamp suffix to the destination filename
6. WHEN the user chooses to skip, THE Application SHALL leave both files unchanged and continue with the next file

### Requirement 4: Timestamp Suffix Generation

**User Story:** As a user, I want conflicting files to have timestamps appended to their names, so that I can preserve both versions without data loss.

#### Acceptance Criteria

1. WHEN appending a timestamp suffix, THE Timestamp_Suffix SHALL use the format "_YYYYMMDD_HHMMSS"
2. THE Application SHALL insert the timestamp suffix before the file extension (e.g., "document.txt" becomes "document_20241226_143022.txt")
3. THE Application SHALL handle files without extensions by appending the timestamp suffix to the end of the filename
4. THE Application SHALL ensure the generated filename is valid for the Windows file system
5. IF a file with the timestamped name already exists, THE Application SHALL increment a counter suffix (e.g., "_20241226_143022_1.txt")
6. THE Application SHALL preserve the original file extension exactly as it appears in the source file

### Requirement 5: Skip Mode Operation

**User Story:** As a user, I want the option to skip confirmation prompts during batch operations, so that I can process large numbers of files efficiently.

#### Acceptance Criteria

1. THE Application SHALL provide a "Skip confirmation prompts" checkbox or toggle
2. WHEN Skip_Mode is enabled, THE Application SHALL automatically append timestamp suffixes to conflicting files without prompting
3. WHEN Skip_Mode is enabled, THE Application SHALL log all automatic conflict resolutions
4. THE Application SHALL allow toggling Skip_Mode on or off during operation
5. WHEN Skip_Mode is disabled, THE Application SHALL resume showing confirmation dialogs for conflicts

### Requirement 6: File Move Operations

**User Story:** As a user, I want to move files from source to destination efficiently, so that I can organize my files without manual copying.

#### Acceptance Criteria

1. THE Application SHALL move files from source folder to destination folder (not copy)
2. WHEN moving files without conflicts, THE Move_Operation SHALL preserve original filenames
3. WHEN moving files with resolved conflicts, THE Move_Operation SHALL use the timestamped filename
4. THE Application SHALL display progress information during batch move operations
5. IF a move operation fails, THE Application SHALL report the error and continue with remaining files
6. THE Application SHALL provide the ability to move selected files or all eligible files

### Requirement 7: User Interface and Feedback

**User Story:** As a user, I want clear visual feedback about file operations, so that I can monitor progress and understand what actions are being taken.

#### Acceptance Criteria

1. THE Application SHALL display a list of files in the source folder with their status
2. THE Application SHALL indicate which files have conflicts, are ready to move, or are identical
3. THE Application SHALL show progress bars or status indicators during file operations
4. THE Application SHALL display a log of completed operations including any timestamp suffixes added
5. THE Application SHALL provide clear error messages when operations fail
6. THE Application SHALL allow users to review the operation log before and after file moves