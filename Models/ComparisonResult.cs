using System;
using System.Collections.Generic;

namespace FileFolderSync.Models;

/// <summary>
/// Represents the result of comparing two files.
/// </summary>
public class ComparisonResult
{
    /// <summary>
    /// Gets or sets whether the files are identical (same size and modification time).
    /// </summary>
    public bool FilesIdentical { get; set; }

    /// <summary>
    /// Gets or sets whether the file sizes differ.
    /// </summary>
    public bool SizesDiffer { get; set; }

    /// <summary>
    /// Gets or sets whether the modification times differ.
    /// </summary>
    public bool TimesDiffer { get; set; }

    /// <summary>
    /// Gets or sets the source file size in bytes.
    /// </summary>
    public long SourceSize { get; set; }

    /// <summary>
    /// Gets or sets the destination file size in bytes.
    /// </summary>
    public long DestSize { get; set; }

    /// <summary>
    /// Gets or sets the source file modification time.
    /// </summary>
    public DateTime SourceModified { get; set; }

    /// <summary>
    /// Gets or sets the destination file modification time.
    /// </summary>
    public DateTime DestModified { get; set; }

    /// <summary>
    /// Returns a string representation of the comparison result.
    /// </summary>
    public override string ToString()
    {
        if (FilesIdentical)
            return "Files are identical";
        
        var differences = new List<string>();
        if (SizesDiffer)
            differences.Add($"Size: {SourceSize} vs {DestSize}");
        if (TimesDiffer)
            differences.Add($"Modified: {SourceModified:yyyy-MM-dd HH:mm:ss} vs {DestModified:yyyy-MM-dd HH:mm:ss}");
        
        return $"Files differ - {string.Join(", ", differences)}";
    }
}