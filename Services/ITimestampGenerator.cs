namespace FileFolderSync.Services;

/// <summary>
/// Interface for generating timestamp suffixes and applying them to filenames for conflict resolution.
/// </summary>
public interface ITimestampGenerator
{
    /// <summary>
    /// Generates a timestamp suffix in the format _YYYYMMDD_HHMMSS.
    /// </summary>
    /// <returns>Timestamp suffix string</returns>
    string GenerateTimestampSuffix();

    /// <summary>
    /// Applies a timestamp suffix to a filename, handling extensions correctly.
    /// </summary>
    /// <param name="originalPath">Original file path</param>
    /// <param name="timestamp">Timestamp suffix to apply</param>
    /// <returns>New filename with timestamp suffix applied</returns>
    string ApplyTimestampToFilename(string originalPath, string timestamp);
}