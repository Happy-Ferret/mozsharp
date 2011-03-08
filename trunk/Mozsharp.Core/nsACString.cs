using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Mozsharp.Core
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public class nsACString : IDisposable
    {        
        public nsACString()
        {
            XPCom.NS_CStringContainerInit(this);
        }

        public nsACString(string data) : this()
        {
            if (data == null)
                throw new ArgumentException("data");

            XPCom.NS_CStringSetData(this, data, data.Length);
        }

        public override string ToString()
        {
            IntPtr aData;
            int len = XPCom.NS_CStringGetData(this, out aData, IntPtr.Zero);

            if (aData != IntPtr.Zero && len > 0)
            {
                return Marshal.PtrToStringAnsi(aData);
            }

            return null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            XPCom.NS_CStringContainerFinish(this);
            GC.SuppressFinalize(this);
        }

        ~nsACString()
        {
            Dispose();
        }

        #endregion
    }
}
