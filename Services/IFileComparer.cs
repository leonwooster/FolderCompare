using System.Collections.Generic;
using FileFolderSync.Models;

namespace FileFolderSync.Services;

/// <summary>
/// Interface for comparing files and detecting conflicts between source and destination folders.
/// </summary>
public interface IFileComparer
{
    /// <summary>
    /// Compares two files at the specified paths and returns detailed comparison results.
    /// </summary>
    /// <param name="sourcePath">Path to the source file</param>
    /// <param name="destPath">Path to the destination file</param>
    /// <returns>ComparisonResult containing detailed comparison information</returns>
    ComparisonResult CompareFiles(string sourcePath, string destPath);

    /// <summary>
    /// Scans source and destination folders to find all file conflicts.
    /// </summary>
    /// <param name="sourceFolder">Path to the source folder</param>
    /// <param name="destFolder">Path to the destination folder</param>
    /// <returns>List of FileConflict objects representing detected conflicts</returns>
    List<FileConflict> FindConflicts(string sourceFolder, string destFolder);
}