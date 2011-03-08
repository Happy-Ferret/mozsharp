using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MozSharp;

namespace MozSharpTestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MozWebBrowser.InitializeXulRunner(@"D:\xulrunner-sdk\bin");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
