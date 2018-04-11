using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdvancedTextEditorCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String forderpath = System.IO.Directory.GetCurrentDirectory() + "\\F\\1.swf";
            axShockwaveFlash1.Movie = forderpath;
            axShockwaveFlash1.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Stop();
        }
    }
}
