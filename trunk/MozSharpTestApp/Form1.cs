using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MozSharp;

namespace MozSharpTestApp
{
    public partial class Form1 : Form
    {
        MozWebBrowser _webBrowser; 

        public Form1()
        {            
            InitializeComponent();
            _webBrowser = new MozWebBrowser();
            _webBrowser.Dock = DockStyle.Fill;
            Controls.Add(_webBrowser); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
