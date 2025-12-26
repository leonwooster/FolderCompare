using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileFolderSync.UI;

/// <summary>
/// Main application form for File Folder Sync.
/// This is a placeholder implementation that will be expanded in later tasks.
/// </summary>
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Basic form setup - will be expanded in UI implementation tasks
        this.Text = "File Folder Sync";
        this.Size = new Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        
        // Add a placeholder label
        var label = new Label
        {
            Text = "File Folder Sync - Ready for Implementation",
            AutoSize = true,
            Location = new Point(20, 20)
        };
        this.Controls.Add(label);
    }
}