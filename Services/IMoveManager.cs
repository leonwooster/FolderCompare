using System.Collections.Generic;
using System.Threading.Tasks;
using FileFolderSync.Models;

namespace FileFolderSync.Services;

/// <summary>
/// Interface for managing file move operations with conflict resolution support.
/// </summary>
public interface IMoveManager
{
    /// <summary>
    /// Moves a single file from source to destination with specified conflict resolution.
    /// </summary>
    /// <param name="sourcePath">Path to the source file</param>
    /// <param name="destPath">Path to the destination file</param>
    /// <param name="resolution">How to resolve conflicts if they occur</param>
    /// <returns>Task containing MoveResult with operation details</returns>
    Task<MoveResult> MoveFileAsync(string sourcePath, string destPath, ConflictResolution resolution);

    /// <summary>
    /// Moves multiple files in a batch operation with progress reporting.
    /// </summary>
    /// <param name="requests">List of file move requests to process</param>
    /// <param name="skipConfirmation">Whether to skip confirmation prompts (skip mode)</param>
    /// <returns>Task containing BatchMoveResult with overall operation results</returns>
    Task<BatchMoveResult> MoveBatchAsync(List<FileMoveRequest> requests, bool skipConfirmation);
}