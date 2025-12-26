using System;
using FsCheck;

namespace FileFolderSync.Tests;

/// <summary>
/// Base class for property-based tests using FsCheck.NET.
/// Provides common configuration and utilities for property testing.
/// </summary>
public abstract class PropertyTestBase
{
    /// <summary>
    /// Runs a simple property test to verify FsCheck is working.
    /// This will be expanded when we implement actual property tests.
    /// </summary>
    protected static void VerifyFsCheckSetup()
    {
        // Simple property test to verify FsCheck.NET is working
        var property = Prop.ForAll<int, int>((x, y) => x + y == y + x);
        Check.Quick(property);
    }
}