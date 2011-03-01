using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MozSharp.XPCom
{
    public static class XPCom
    {
        [DllImport("xpcom.dll", CharSet=CharSet.Unicode, CallingConvention=CallingConvention.Cdecl)]
        internal static extern uint NS_InitXPCOM2(out IntPtr aResult, IntPtr aBinDirectory, IntPtr aAppFileLocationProvider);

        public static void Initialize(string xulrunnerPath)
        {
            string path = Environment.GetEnvironmentVariable("path");
            path += ";" + xulrunnerPath;
            Environment.SetEnvironmentVariable("path", path); 

            IntPtr aResult;
            uint res = NS_InitXPCOM2(out aResult, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
