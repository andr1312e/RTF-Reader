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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Movie = Application.StartupPath + @"\1.swf";
            axShockwaveFlash1.Playing = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Playing = false;
        }
    }
}
