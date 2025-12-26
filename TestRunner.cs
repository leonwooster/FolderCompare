using System;
using FileFolderSync.Tests;

namespace FileFolderSync;

/// <summary>
/// Simple test runner to verify setup is working correctly.
/// This will be removed once proper testing infrastructure is in place.
/// </summary>
public static class TestRunner
{
    public static void RunTests()
    {
        try
        {
            SetupVerificationTests.RunSetupTests();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Tests failed: {ex.Message}");
            throw;
        }
    }
}