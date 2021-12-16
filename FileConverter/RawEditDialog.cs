using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace FileConverter
{
    public partial class RawEditDialog : Form
    {
        MainForm mainForm;
        string tempPath = String.Empty;
        Encoding encoding;

        public RawEditDialog(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            tempPath = Path.GetDirectoryName(mainForm.Path) + "/tmp06.txt";
            encoding = Utility.GetEncoding(mainForm.Path);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (mainForm.Path == null ||
                string.IsNullOrWhiteSpace(mainForm.Path) ||
                !File.Exists(mainForm.Path)) return;

            using (var reader = new StreamReader(mainForm.Path, true))
            {
                var sw = File.CreateText(tempPath);
                sw.Write(reader.ReadToEnd());
                sw.Close();
            }
            try
            {
                using (var writer = new StreamWriter(mainForm.Path, true, encoding))
                {
                    writer.WriteLine();
                    writer.WriteLine();
                    foreach(var line in EditTextBox.Lines)
                    {
                        writer.WriteLine(line);
                    }
                    
                }
                File.Delete(tempPath);
            }
            catch
            {
                using (var writer = new StreamWriter(mainForm.Path, false, encoding))
                {
                    using (var reader = new StreamReader(tempPath, true))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
                File.Delete(tempPath);
            }

            DialogResult = DialogResult.OK;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            
        }
        
    }
}
