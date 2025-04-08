using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DyDrums.Services;
public class VerticalProgressBar : ProgressBar
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    private const int PBM_SETBARCOLOR = 0x0409;
    private const int PBS_VERTICAL = 0x04;

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.Style |= PBS_VERTICAL;
            return cp;
        }
    }
}
