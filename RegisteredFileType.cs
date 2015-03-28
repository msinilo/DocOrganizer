using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DocOrganizer
{
    class RegisteredFileType
    {
        [DllImport("shell32.dll", EntryPoint = "ExtractIconA",
            CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr ExtractIcon
            (int hInst, string lpszExeFileName, int nIconIndex);  
    }
}
