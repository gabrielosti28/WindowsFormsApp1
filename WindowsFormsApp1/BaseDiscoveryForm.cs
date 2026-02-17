using System.Drawing;
using System.Windows.Forms;

public abstract class BaseDiscoveryForm : Form
{
    protected void ShowShortcutDetails(dynamic shortcut) { }
    protected void AddSectionTitle(Form form, string title, ref int yPos) { }
    protected void AddTextBox(Form form, string text, ref int yPos, int height, Color color) { }
}