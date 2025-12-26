namespace FileFolderSync.Models;

/// <summary>
/// Enumeration of possible conflict resolution strategies.
/// </summary>
public enum ConflictResolution
{
    /// <summary>
    /// Overwrite the destination file with the source file.
    /// </summary>
    Overwrite,

    /// <summary>
    /// Append a timestamp suffix to create a unique filename.
    /// </summary>
    AppendTimestamp,

    /// <summary>
    /// Skip this file and leave both files unchanged.
    /// </summary>
    Skip,

    /// <summary>
    /// /// Cancel the entire operation.
    /// </summary>
    Cancel
}