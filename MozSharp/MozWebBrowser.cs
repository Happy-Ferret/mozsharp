using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mozsharp.Core;

namespace MozSharp
{
    public class MozWebBrowser : Control
    {        
        public static void InitializeXulRunner(string xulrunnerPath) 
        {
            XPCom.InitializeXulRunner(xulrunnerPath);
        }

        public MozWebBrowser()
        {
        }
    }
}
