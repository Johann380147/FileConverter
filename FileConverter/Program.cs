using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConverter
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
            
            var startdialog = new StartDialog();
            var result = startdialog.ShowDialog();
            if(result == DialogResult.Yes)
                Application.Run(new MainForm(Utility.GetLocalPath(), true));
            else if (result == DialogResult.OK)
                Application.Run(new MainForm(Utility.GetExternalPath(), false));
            else if (result == DialogResult.Ignore)
                Application.Run(new TreeForm());
        }
    }
}
