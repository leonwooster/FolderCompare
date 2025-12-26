using System;
using System.Collections.Generic;
using System.Linq;

namespace FileFolderSync.Models;

/// <summary>
/// Represents the result of a batch file move operation.
/// </summary>
public class BatchMoveResult
{
    /// <summary>
    /// Gets or sets the list of individual move results.
    /// </summary>
    public List<MoveResult> Results { get; set; } = new List<MoveResult>();

    /// <summary>
    /// Gets or sets the total number of files processed.
    /// </summary>
    public int TotalFiles { get; set; }

    /// <summary>
    /// Gets the number of successful moves.
    /// </summary>
    public int SuccessfulMoves => Results.Count(r => r.Success);

    /// <summary>
    /// Gets the number of failed moves.
    /// </summary>
    public int FailedMoves => Results.Count(r => !r.Success);

    /// <summary>
    /// Gets whether the entire batch operation was successful (all files moved successfully).
    /// </summary>
    public bool AllSuccessful => Results.All(r => r.Success);

    /// <summary>
    /// Gets or sets the overall operation start time.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Gets or sets the overall operation end time.
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Gets the total operation duration.
    /// </summary>
    public TimeSpan Duration => EndTime - StartTime;

    /// <summary>
    /// Returns a string representation of the batch move result.
    /// </summary>
    public override string ToString()
    {
        return $"Batch Move: {SuccessfulMoves}/{TotalFiles} successful, {FailedMoves} failed, Duration: {Duration:mm\\:ss}";
    }
}