using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Mozsharp.Core
{
    public static class XPCom
    {
        [DllImport("xpcom.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_NewNativeLocalFile(nsACString aPath, bool aFollowLinks, out IntPtr aResult);

        [DllImport("xpcom", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_CStringContainerInit(nsACString aString);

        [DllImport("xpcom", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_CStringContainerFinish(nsACString aString);

        [DllImport("xpcom", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_CStringSetData(nsACString aString, string aData, int aDataLength);

        [DllImport("xpcom", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_CStringGetData(nsACString aString, out IntPtr aData, IntPtr aTerminated);

        [DllImport("xpcom", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int NS_InitXPCOM2(out IntPtr aResult, IntPtr aBinDirectory, IntPtr aAppFileLocationProvider);

        public static void InitializeXulRunner(string xulrunnerPath)
        {
            if (!Directory.Exists(xulrunnerPath))
                throw new DirectoryNotFoundException(); 

            string path = Environment.GetEnvironmentVariable("path");
            path += ";" + xulrunnerPath;
            Environment.SetEnvironmentVariable("path", path);

            IntPtr serviceManager; 
            IntPtr binDir = XPCom.NewNativeLocalFile(xulrunnerPath, false);
            int nsresult = NS_InitXPCOM2(out serviceManager, binDir, IntPtr.Zero);

            if (NS_FAILED(nsresult))
            {
                throw new Exception(); 
            }
        }

        public static IntPtr NewNativeLocalFile(string path, bool followLinks)
        {
            IntPtr aResult;
            using (nsACString aPath = new nsACString(path))
            {               
                NS_NewNativeLocalFile(aPath, followLinks, out aResult);
            }
            return aResult; 
        }

        public static bool NS_SUCCEEDED(int nsresult)
        {         
            return ((uint)nsresult & 0x80000000) == 0; 
        }

        public static bool NS_FAILED(int nsresult)
        {
            return ((uint)nsresult & 0x80000000) > 0; 
        }
    }
}
