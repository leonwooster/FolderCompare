using System;
using System.Windows.Forms;
using FileFolderSync.UI;

namespace FileFolderSync;

/// <summary>
/// Main entry point for the File Folder Sync application.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        // Check if running in test mode
        if (args.Length > 0 && args[0] == "--test")
        {
            // Allocate a console for the Windows Forms app
            AllocConsole();
            Console.WriteLine("Running in test mode...");
            TestRunner.RunTests();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // TODO: Set up dependency injection container when implementing services
        // For now, create a placeholder main form
        Application.Run(new MainForm());
    }
    
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private static extern bool AllocConsole();
}