namespace FileFolderSync.Models;

/// <summary>
/// Enumeration of types of file conflicts that can be detected.
/// </summary>
public enum ConflictType
{
    /// <summary>
    /// Files have different sizes.
    /// </summary>
    SizeDifference,

    /// <summary>
    /// Files have different modification timestamps.
    /// </summary>
    TimeDifference,

    /// <summary>
    /// Files have both different sizes and different modification timestamps.
    ///  /// </summary>
    Both
}