﻿using System.Runtime.InteropServices;

namespace DyDrums.Views;
public class VerticalProgressBar : ProgressBar
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern nint SendMessage(nint hWnd, int msg, nint wParam, nint lParam);

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
