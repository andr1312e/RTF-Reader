using System;
using System.Windows.Forms;

namespace AdvancedTextEditorCSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdvancedTextEditor());
            //Application.Run(new mytest.Form1("..//..//..//Строевой устав.txt"));
        }
    }
}
