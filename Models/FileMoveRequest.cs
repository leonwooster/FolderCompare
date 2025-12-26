namespace FileFolderSync.Models;

/// <summary>
/// Represents a request to move a file from source to destination.
/// </summary>
public class FileMoveRequest
{
    /// <summary>
    /// Gets or sets the source file path.
    /// </summary>
    public string SourcePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the destination file path.
    /// </summary>
    public string DestinationPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the conflict resolution strategy to use.
    /// </summary>
    public ConflictResolution Resolution { get; set; }

    /// <summary>
    /// Gets or sets whether this file has a detected conflict.
    /// </summary>
    public bool HasConflict { get; set; }
    /// Returns a string representation of the move request.
    /// </summary>
    public override string ToString()
    {
        var conflictStatus = HasConflict ? " (Conflict)" : "";
        return $"{SourcePath} -> {DestinationPath}{conflictStatus}";
    }
}