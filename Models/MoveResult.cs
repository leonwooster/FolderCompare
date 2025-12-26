namespace FileFolderSync.Models;

/// <summary>
/// Represents the result of a file move operation.
/// </summary>
public class MoveResult
{
    /// <summary>
    /// Gets or sets whether the move operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the original file path before the move.
    /// </summary>
    public string OriginalPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the final file path after the move (may include timestamp suffix).
    /// </summary>
    public string FinalPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the error message if the operation failed.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the conflict resolution strategy that was applied.
    /// </summary>
    public ConflictResolution ResolutionApplied { get; set; }

    /// <summary>
    /// Returns a string representation of the move result.
    /// </summary>
    /// public override string ToString()
    {
        if (Success)
            return $"Successfully moved {OriginalPath} to {FinalPath} (Resolution: {ResolutionApplied})";
        else
            return $"Failed to move {OriginalPath}: {ErrorMessage}";
    }
}  /// 