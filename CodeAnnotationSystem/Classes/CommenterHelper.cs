using System;
using System.Collections.Generic;
using System.Text;

namespace NppPluginNET
{
    public static class CommenterHelper
    {
        public static int GetSelectionPosition(ref IntPtr scintilla, SciMsg msg)
        {
            return (int)Win32.SendMessage(scintilla, msg, 0, 0);
        }

        public static int GetSelectionLineFromPosition(ref IntPtr scintilla, int position)
        {
            return (int)Win32.SendMessage(scintilla, SciMsg.SCI_LINEFROMPOSITION, position, 0) + 1;
        }

        public static int GetSelectionPositionFromLine(ref IntPtr scintilla, int position)
        {
            return (int)Win32.SendMessage(scintilla, SciMsg.SCI_POSITIONFROMLINE, position, 0);
        }
    }
}
