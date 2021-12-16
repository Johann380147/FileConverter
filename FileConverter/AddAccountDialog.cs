using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace FileConverter
{
    public partial class AddAccountDialog : Form
    {
        MainForm mainForm;
        string tempPath = String.Empty;
        Encoding encoding;

        public AddAccountDialog(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            tempPath = Path.GetDirectoryName(mainForm.Path) + "/tmp06.txt";
            encoding = Utility.GetEncoding(mainForm.Path);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (mainForm.Path == null ||
                string.IsNullOrWhiteSpace(mainForm.Path) ||
                !File.Exists(mainForm.Path) ||
                string.IsNullOrWhiteSpace(txtCategory.Text)) return;
            
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
                    writer.WriteLine(">" + txtCategory.Text);
                    writer.WriteLine(txtUsername.Text);
                    writer.WriteLine(txtPassword.Text);
                    writer.WriteLine(txtExtras.Text);
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnGenPassword_Click(object sender, EventArgs e)
        {
            string password = "-";
            while (!password.StartsWith("-"))
            {
                password = GeneratePassword.GenerateIdentifier(15);
            }

            txtPassword.Text = password;
        }
    }
}
