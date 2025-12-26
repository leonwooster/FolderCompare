using System.IO;

namespace FileFolderSync.Models;

/// <summary>
/// Represents a file conflict between source and destination folders.
/// </summary>
public class FileConflict
{
    /// <summary>
    /// Gets or sets the name of the conflicting file.
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the source file information.
    /// </summary>
    public FileInfo? SourceFile { get; set; }

    /// <summary>
    /// Gets or sets the destination file information.
    /// </summary>
    public FileInfo? DestinationFile { get; set; }

    /// <summary>
    /// Gets or sets the type of conflict detected.
    /// </summary>
    public ConflictType Type { get; set; }

    /// <summary>
    /// Returns a string representation of the file conflict.
    /// </summary>
    public override string ToString()
    {
        return $"Conflict: {FileName} ({Type})";
    }
}