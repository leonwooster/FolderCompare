using System;
using FsCheck;
using FileFolderSync.Models;

namespace FileFolderSync.Tests;

/// <summary>
/// Tests to verify that the project setup and FsCheck.NET are working correctly.
/// </summary>
public class SetupVerificationTests : PropertyTestBase
{
    public static void RunSetupTests()
    {
        Console.WriteLine("Running setup verification tests...");
        
        // Test 1: Verify project compiles and basic types are available
        ProjectSetup_ShouldCompile();
        
        // Test 2: Verify FsCheck is working
        FsCheckSetup_ShouldWork();
        
        Console.WriteLine("All setup tests passed!");
    }
    
    private static void ProjectSetup_ShouldCompile()
    {
        // Simple test to verify project compiles and basic types are available
        var conflictResolution = ConflictResolution.AppendTimestamp;
        var conflictType = ConflictType.SizeDifference;
        
        // Verify the enums work as expected
        if (conflictResolution != ConflictResolution.AppendTimestamp)
            throw new Exception("ConflictResolution enum not working correctly");
            
        if (conflictType != ConflictType.SizeDifference)
            throw new Exception("ConflictType enum not working correctly");
            
        Console.WriteLine("✓ Project setup test passed");
    }

    private static void FsCheckSetup_ShouldWork()
    {
        // Simple property test to verify FsCheck.NET is working
        var property = Prop.ForAll<int, int>((x, y) => x + y == y + x);
        
        try
        {
            Check.Quick(property);
            Console.WriteLine("✓ FsCheck setup test passed");
        }
        catch (Exception ex)
        {
            throw new Exception($"FsCheck setup failed: {ex.Message}");
        }
    }
}